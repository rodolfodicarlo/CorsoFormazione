using Corso.Entity.IUnitOfWork;
using Corso.Service.IServices;
using Corso.Service.Services;
using MiddlewareExceptionHandler.ExceptionHandling;

namespace Corso.WebApi.Extensions
{
    /// <summary>
    /// Classe statica che contiene estensioni per la configurazione di servizi personalizzati.
    /// </summary>
    public static class CustomServiceExtensions
    {
        /// <summary>
        /// Metodo di estensione per aggiungere e configurare i servizi personalizzati all'interno di <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">La raccolta di servizi dell'applicazione.</param>
        /// <returns>Restituisce la stessa <see cref="IServiceCollection"/> per consentire ulteriori configurazioni fluenti.</returns>
        public static IServiceCollection AddCustomService(this IServiceCollection services)
        {
            try
            {
                #region Middleware

                services.AddScoped<GlobalExceptionHandlingMiddleware>();

                #endregion

                #region Service

                services.AddScoped<IAulaService, AulaService>();

                #endregion

                #region UnitOfWork

                services.AddScoped<IUnitOfWork, UnitOfWork>();

                #endregion

                return services;
            }
            catch
            {
                throw;
            }
        }
    }
}
