using Corso.Entity.DAL;
using Microsoft.EntityFrameworkCore;

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
    }
}
