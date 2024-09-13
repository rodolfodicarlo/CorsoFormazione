using AutoMapper;
using Corso.Service.DTOs.AulaDTOs;
using Corso.WebApi.Models.AulaModels;
using Corso.WebApi.Models.DocenteModels;

namespace Corso.WebApi.Helpers.InjectableHelpers
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

            CreateMap<CreaAulaModel, CreaAulaDTO>();
            CreateMap<ModificaAulaModel, ModificaAulaDTO>();

            #endregion
            #region Aula

            CreateMap<CreaDocenteModel, CreaAulaDTO>();
            CreateMap<ModificaDocenteModel, ModificaAulaDTO>();

            #endregion

        }
    }
}
