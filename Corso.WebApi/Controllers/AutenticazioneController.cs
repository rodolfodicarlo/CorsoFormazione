using AutoMapper;
using Corso.Service.DTOs.AutenticazioneDTOs;
using Corso.WebApi.Models.AutenticazioneModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MiddlewareExceptionHandler.Controllers;
using MiddlewareExceptionHandler.ExceptionConfiguration;
using MiddlewareExceptionHandler.ResponseModel;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Corso.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class IdentityController : BaseApiController
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentityController(IConfiguration configuration, IMapper mapper, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ILogger<AulaController> logger) : base(logger)
        {
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponseModel<TokenDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetToken(TokenRequestModel model)
        {
            try
            {
                string username = _configuration["ServerCredential:Username"];
                string password = _configuration["ServerCredential:Password"];

                if (model.Username == username && model.Password == password)
                {
                    TokenDTO tokenDTO = CreateToken([], null, null);
                    return StandardMessageResult(HttpStatusCode.OK, result: tokenDTO);
                }
                else
                {
                    throw new BadRequestException("Invalid credentials.", "Ops... Qualcosa è andato storto");
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseModel<TokenDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                IdentityUser user = await _userManager.FindByEmailAsync(model.Email) ?? throw new BadRequestException("Invalid or non-existent email address.", "Indirizzo email errato");
                if (!await _userManager.CheckPasswordAsync(user, model.Password)) throw new BadRequestException("Invalid password.", "Passwor non valida");
                if (user.LockoutEnabled) throw new BadRequestException("Inactive AspNetUser.", "Account non attivo");
                if (!user.EmailConfirmed) throw new BadRequestException("The email address has not been confirmed yet.", "Email non confermata");
                List<string>? userRolesList = (await _userManager.GetRolesAsync(user)).ToList();
                List<Claim> userRoles = new List<Claim>();
                foreach (string userRole in userRolesList)
                {
                    Claim roleClaim = new Claim(ClaimTypes.Role, userRole);
                    userRoles.Add(roleClaim);
                }
                TokenDTO tokenDTO = CreateToken(userRoles, user.Id, user.Email);
                return StandardMessageResult(HttpStatusCode.OK, result: tokenDTO);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseModel<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult> RegisterDocente([FromBody] RegisterModel model)
        {
            try
            {
                IdentityUser? user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    throw new BadRequestException("Email already in use.", "Email in uso");
                }
                else
                {
                    user = new();
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                    if (!result.Succeeded)
                    {
                        throw new CustomException("The AspNetUser could not be saved, please try again.", HttpStatusCode.InternalServerError, "Server error");
                    }
                    else
                    {
                        try
                        {
                            await CreateRole("Docente");
                            IdentityResult resultRole = await _userManager.AddToRoleAsync(user, "Docente");
                            if (!result.Succeeded)
                            {
                                throw new CustomException(message: $"The role Docente could not be assigned, please try again.", HttpStatusCode.InternalServerError, "Server error");
                            }
                            return StandardMessageResult(HttpStatusCode.OK, result: true);
                        }
                        catch
                        {
                            await _userManager.DeleteAsync(user);
                            throw;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseModel<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult> RegisterStudente([FromBody] RegisterModel model)
        {
            try
            {
                IdentityUser? user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    throw new BadRequestException("Email already in use.", "Email in uso");
                }
                else
                {
                    user = new();
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                    if (!result.Succeeded)
                    {
                        throw new CustomException("The AspNetUser could not be saved, please try again.", HttpStatusCode.InternalServerError, "Server error");
                    }
                    else
                    {
                        try
                        {
                            await CreateRole("Studente");
                            IdentityResult resultRole = await _userManager.AddToRoleAsync(user, "Studente");
                            if (!result.Succeeded)
                            {
                                throw new CustomException(message: $"The role Docente could not be assigned, please try again.", HttpStatusCode.InternalServerError, "Server error");
                            }
                            return StandardMessageResult(HttpStatusCode.OK, result: true);
                        }
                        catch
                        {
                            await _userManager.DeleteAsync(user);
                            throw;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #region Private

        private TokenDTO CreateToken(List<Claim> userRoles, string? aspNetUserId, string? email)
        {
            try
            {
                List<Claim> claims = new();

                if (!string.IsNullOrEmpty(aspNetUserId) && !string.IsNullOrEmpty(email))
                {
                    foreach (Claim userRole in userRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, userRole.Value));
                    }

                    claims.Add(new Claim(ClaimTypes.Email, email));
                    claims.Add(new Claim("aspNetUserId", aspNetUserId));
                }

                string jwtExpireMinutesString = _configuration["Authentication:JwtExpireMinutes"];
                double jwtExpireMinutes = double.Parse(jwtExpireMinutesString);

                DateTime accessTkExpires = DateTime.Now.AddMinutes(jwtExpireMinutes);
                string accessTokenString = GenerateJWT(accessTkExpires, claims);

                string JwtRefreshExpireMinutesString = _configuration["Authentication:JwtRefreshExpireMinutes"];
                double JwtRefreshExpireMinutes = double.Parse(JwtRefreshExpireMinutesString);

                DateTime refreshTkExpires = DateTime.Now.AddMinutes(JwtRefreshExpireMinutes);
                string refreshTokenString = GenerateJWT(refreshTkExpires, claims);

                TokenDTO token = new()
                {
                    accessToken = accessTokenString,
                    accessTokenExpire = DateTimeOffset.UtcNow.AddMinutes(jwtExpireMinutes).ToUnixTimeMilliseconds(),
                    refreshToken = refreshTokenString,
                    refreshTokenExpire = DateTimeOffset.UtcNow.AddMinutes(JwtRefreshExpireMinutes).ToUnixTimeMilliseconds()
                };

                return token;
            }
            catch
            {
                throw;
            }
        }

        private string GenerateJWT(DateTime expires, List<Claim> claims)
        {
            try
            {
                string jwtKey = _configuration["Authentication:JwtKey"];
                SymmetricSecurityKey secretKey = new(Encoding.UTF8.GetBytes(jwtKey));

                var token = new JwtSecurityToken
                (
                    issuer: _configuration["Authentication:JwtAudience"],
                    audience: _configuration["Authentication:JwtIssuer"],
                    expires: expires,
                    claims: claims,
                    signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch
            {
                throw;
            }
        }

        private async Task CreateRole(string role)
        {
            try
            {
                bool roleExist = await _roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    IdentityRole newRole = new IdentityRole(role);
                    IdentityResult result = await _roleManager.CreateAsync(newRole);

                    if (!result.Succeeded)
                    {
                        throw new CustomException($"The role could not be saved. Try again.", HttpStatusCode.InternalServerError, "Server error");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
