using AutoMapper;
using Corso.Entity.DAL;
using Corso.Service.DTOs.AulaDTOs;

namespace Corso.Service.Helpers.InjectableHelpers
{
    /// <summary>
    /// Helper per la configurazione di AutoMapper.
    /// Definisce le mappature tra i modelli DTO e le entità.
    /// </summary>
    public class AutoMapperHelper : Profile
    {
        /// <summary>
        /// Costruttore della classe AutoMapperHelper.
        /// Configura le mappature per l'entità Aula e i relativi DTO.
        /// </summary>
        public AutoMapperHelper()
        {
            #region Aula

            CreateMap<CreaAulaDTO, Aula>();
            CreateMap<ModificaAulaDTO, Aula>();
            CreateMap<Aula, AulaDTO>();

            #endregion
        }
    }
}
