using Corso.Entity.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiddlewareExceptionHandler.ExceptionConfiguration;
using System.Net;

namespace Corso.WebApi.Extensions
{
    /// <summary>
    /// Classe statica che contiene estensioni per la configurazione dei servizi applicativi.
    /// </summary>
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// Metodo di estensione per aggiungere e configurare i servizi applicativi all'interno di <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">La raccolta di servizi dell'applicazione.</param>
        /// <param name="configuration">L'oggetto di configurazione dell'applicazione.</param>
        /// <returns>Restituisce la stessa <see cref="IServiceCollection"/> per consentire ulteriori configurazioni fluenti.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddCors(options => options.AddPolicy(
                    name: "CorsPolicy",
                    policy =>
                    {
                        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    })
                );

                services.AddDbContext<CorsoFormazioneContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionStrings:DatabaseConnection")!));

                return services;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo che crea un admin durante l'avvio dell'applicazione se non è già presente.
        /// </summary>
        /// <param name="app">L'istanza di <see cref="WebApplication"/> che rappresenta l'applicazione web.</param>
        /// <returns></returns>
        /// <exception cref="CustomException"> Generata se l'inizializzazione fallisce.</exception>
        public static async Task InitializeDataAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>() ?? throw new CustomException("Unable to resolve RoleManager<IdentityRole> from service provider.", code: HttpStatusCode.InternalServerError);
                UserManager<IdentityUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>() ?? throw new CustomException("Unable to resolve UserManager<IdentityUser> from service provider.", code: HttpStatusCode.InternalServerError);

                string roleName = "Admin";
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(roleName));
                    if (!result.Succeeded)
                    {
                        throw new CustomException(
                            $"Error creating role Admin: {string.Join(", ", result.Errors.Select(e => e.Description))}",
                            HttpStatusCode.InternalServerError,
                           "Server error"
                        );
                    }
                }

                IdentityUser? adminUser = await userManager.FindByNameAsync("admin@example.com");
                if (adminUser == null)
                {
                    adminUser = new IdentityUser
                    {
                        UserName = "admin@example.com",
                        Email = "admin@example.com",
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    };
                    IdentityResult result = await userManager.CreateAsync(adminUser, "Admin1234?");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        throw new CustomException(
                            $"Error creating admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}",
                            HttpStatusCode.InternalServerError,
                            "Server error"
                        );
                    }
                }

                if (adminUser != null && adminUser.LockoutEnabled != false)
                {
                    adminUser.LockoutEnabled = false;
                    IdentityResult updateResult = await userManager.UpdateAsync(adminUser);
                    if (!updateResult.Succeeded)
                    {
                        throw new CustomException(
                            $"Error updating admin user: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}",
                            HttpStatusCode.InternalServerError,
                            "Server error"
                        );
                    }
                }
            }
        }
    }
}
