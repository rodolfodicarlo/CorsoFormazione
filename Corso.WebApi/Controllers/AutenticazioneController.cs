using AutoMapper;
using Corso.Service.DTOs.AutenticazioneDTOs;
using Corso.Service.DTOs.DocenteDTOs;
using Corso.Service.DTOs.StudenteDTOs;
using Corso.Service.IServices;
using Corso.WebApi.Models.AutenticazioneModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MiddlewareExceptionHandler.Controllers;
using MiddlewareExceptionHandler.ExceptionConfiguration;
using MiddlewareExceptionHandler.ResponseModel;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Corso.WebApi.Controllers
{
    /// <summary>
    /// Controller per la gestione dell'autenticazione e della registrazione.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutenticazioneController : BaseApiController
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IDocenteService _docenteService;
        private readonly IStudenteService _studenteService;

        /// <summary>
        /// Costruttore del controller Autenticazione.
        /// </summary>
        /// <param name="configuration">Configuration per configurare l'applicazione.</param>
        /// <param name="mapper">Mapper per la trasformazione dei modelli.</param>
        /// <param name="roleManager">RoleManger per la gestione dei ruoli all'interno del sistema d'identità.</param>
        /// <param name="userManager">UserManager per la gestione degli utenti del sitema d'identità.</param>
        /// <param name="docenteService">Servizio per la gestione dei docenti.</param>
        /// <param name="studenteService">Servizio per la gestione degli studenti.</param>
        /// <param name="logger">Logger per la gestione dei log.</param>
        public AutenticazioneController(IConfiguration configuration, IMapper mapper, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IDocenteService docenteService, IStudenteService studenteService, ILogger<AulaController> logger) : base(logger)
        {
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _docenteService = docenteService;
            _studenteService = studenteService;
        }

        /// <summary>
        /// Genera un token di accesso.
        /// </summary>
        /// <param name="model">Modello che contiene le credenziali.</param>
        /// <returns>Un oggetto <see cref="ActionResult"/> che contiene il token di accesso.</returns>
        /// <response code="200">Il token di accesso.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponseModel<TokenDTO>), StatusCodes.Status200OK)]
        public ActionResult GetToken(TokenRequestModel model)
        {
            try
            {
                string username = _configuration["ServerCredential:username"] ?? throw new CustomException("Non trovata 'ServerCredential:username' nell'appsetting", HttpStatusCode.InternalServerError, "Server error");
                string password = _configuration["ServerCredential:password"] ?? throw new CustomException("Non trovata 'ServerCredential:password' nell'appsetting", HttpStatusCode.InternalServerError, "Server error");

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

        /// <summary>
        /// Genera un nuovo token di accesso.
        /// </summary>
        /// <returns>Un oggetto <see cref="ActionResult"/> che contiene il token di accesso.</returns>
        /// <response code="200">Il token di accesso.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseModel<TokenDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken()
        {
            try
            {
                string header = HttpContext.Request.Headers["Authorization"].ToString();
               
                if (header == "" || header == null)
                {
                    throw new BadRequestException("Token assente nell'header.", "Ops... Qualcosa è andato storto.");
                }

                string tokenRecuperato = header.Split(" ")[1];
                string jwtKey = _configuration["Authentication:JwtKey"] ?? throw new CustomException("Non trovata 'Authentication:JwtKey' nell'appsetting", HttpStatusCode.InternalServerError, "Server error");
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = _configuration["Authentication:JwtAudience"],
                    ValidAudience = _configuration["Authentication:JwtIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                    RequireSignedTokens = true
                };

                try
                {
                    ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(tokenRecuperato, validationParameters, out SecurityToken validatedToken);
                    List<Claim> ruoli = claimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
                    string? email = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                    string? id = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                    bool ruoloEsiste = true;
                    
                    for (int i = 0; i < ruoli.Count && ruoloEsiste == true; i++)
                    {
                        ruoloEsiste = await _roleManager.RoleExistsAsync(ruoli.ElementAt(i).Value);
                    }
                    
                    if (ruoloEsiste && ruoli != null && ruoli.Count > 0)
                    {
                        TokenDTO tokenDTO = CreateToken(ruoli, id, email);
                        return StandardMessageResult(HttpStatusCode.OK, result: tokenDTO);
                    }
                    else
                    {
                        TokenDTO tokenDTO = CreateToken([], null, null);
                        return StandardMessageResult(HttpStatusCode.OK, result: tokenDTO);
                    }
                }
                catch
                {
                    throw new BadRequestException("Token non valido.", "Ops... Qualcosa è andato storto.");
                }

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Genera il token di login.
        /// </summary>
        /// <param name="model">Modello che contiene le credenziali dell'utente.</param>
        /// <returns>Un oggetto <see cref="ActionResult"/> che contine il token di login.</returns>
        /// <response code="200">Il token di login.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
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

        /// <summary>
        /// Registra un nuovo docente.
        /// </summary>
        /// <param name="model">Contiene i dati per la registrazione di un nuovo docente.</param>
        /// <returns>Un oggetto <see cref="ActionResult"/> che contiene il docente creato.</returns>
        /// <response code="200">Il docente creato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseModel<DocenteDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> RegistraDocente([FromBody] RegisterModel model)
        {
            try
            {
                Guid id = await CreateAspNetUser(model, "Docente");
                DocenteDTO docenteDTO = _mapper.Map<DocenteDTO>(model);
                docenteDTO.IDDocente = id;
                DocenteDTO docenteCreatoDTO = await _docenteService.Create(docenteDTO);
                return StandardMessageResult(HttpStatusCode.OK, result: docenteCreatoDTO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Registra un nuovo studente.
        /// </summary>
        /// <param name="model">Contiene i dati per la registrazione di un nuovo studente.</param>
        /// <returns>Un oggetto <see cref="ActionResult"/> che contiene una booleana che indica se la registrazione è riuscita.</returns>
        /// <response code="200">Una booleana di valore true.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseModel<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult> RegistraStudente([FromBody] RegisterModel model)
        {
            try
            {
                Guid id = await CreateAspNetUser(model, "Studente");
                StudenteDTO studenteDTO = _mapper.Map<StudenteDTO>(model);
                studenteDTO.IDStudente = id;
                await _studenteService.Create(studenteDTO);
                return StandardMessageResult(HttpStatusCode.OK, result: true);
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
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, aspNetUserId));
                }

                string jwtExpireMinutesString = _configuration["Authentication:JwtExpireMinutes"] ?? throw new CustomException("Non trovata 'Authentication:JwtExpireMinutes' nell'appsetting", HttpStatusCode.InternalServerError, "Server error");
                double jwtExpireMinutes = double.Parse(jwtExpireMinutesString);

                DateTime accessTkExpires = DateTime.Now.AddMinutes(jwtExpireMinutes);
                string accessTokenString = GenerateJWT(accessTkExpires, claims);

                string JwtRefreshExpireMinutesString = _configuration["Authentication:JwtRefreshExpireMinutes"] ?? throw new CustomException("Non trovata 'Authentication:JwtRefreshExpireMinutes' nell'appsetting", HttpStatusCode.InternalServerError, "Server error");
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
                string jwtKey = _configuration["Authentication:JwtKey"] ?? throw new CustomException("Non trovata 'Authentication:JwtKey' nell'appsetting", HttpStatusCode.InternalServerError, "Server error");
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

        private async Task<Guid> CreateAspNetUser(RegisterModel model, string role)
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
                            await CreateRole(role);
                            IdentityResult resultRole = await _userManager.AddToRoleAsync(user, role);
                            if (!result.Succeeded)
                            {
                                throw new CustomException(message: $"The role: {role} could not be assigned, please try again.", HttpStatusCode.InternalServerError, "Server error");
                            }
                        }
                        catch
                        {
                            await _userManager.DeleteAsync(user);
                            throw;
                        }
                        return Guid.Parse(user.Id);
                    }
                }
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
