using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Corso.WebApi.Extensions
{
    /// <summary>
    /// Classe statica che contiene estensioni per la configurazione della documentazione Swagger.
    /// </summary>
    public static class SwaggerServiceExtensions
    {
        /// <summary>
        /// Metodo di estensione per aggiungere e configurare la documentazione Swagger all'interno di <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">La raccolta di servizi dell'applicazione.</param>
        /// <returns>Restituisce la stessa <see cref="IServiceCollection"/> per consentire ulteriori configurazioni fluenti.</returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            try
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Corso formazione",
                        Description = "Descrizione corso formazione",
                        Version = "v1"
                    });

                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please insert a valid token",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                    c.EnableAnnotations();
                    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Corso.Service.xml"));
                    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                    c.SupportNonNullableReferenceTypes();
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
