using Corso.Entity.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MiddlewareExceptionHandler.ExceptionConfiguration;
using System.Net;
using System.Text;

namespace Corso.WebApi.Extensions
{
    /// <summary>
    /// Classe per configurare i servizi di identità dell'applicazione.
    /// </summary>
    public static class IdentityServiceExtensions
    {
        /// <summary>
        /// Metodo per configurare i servizi d'identità.
        /// </summary>
        /// <param name="services">Service in cui vengono registrati i servizi.</param>
        /// <param name="configuration">Configuration per accedere alle impostazioni di configurazione.</param>
        /// <returns>Il Service configurato.</returns>
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<CorsoFormazioneContext>()
                    .AddDefaultTokenProviders()
                    .AddRoles<IdentityRole>();

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("TokenRequired", policy =>
                    {
                        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                        policy.RequireAuthenticatedUser();
                    });
                });

                services.AddAuthentication(option =>
                {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidAudience = configuration["Authentication:JwtAudience"],
                        ValidIssuer = configuration["Authentication:JwtIssuer"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:JwtKey"] ?? throw new CustomException("Non trovata 'Authentication:JwtKey' nell'appsetting", HttpStatusCode.InternalServerError, "Server error")))
                    };
                });

                return services;
            }
            catch
            {
                throw;
            }
        }
    }
}
