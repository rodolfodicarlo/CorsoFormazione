using AutoMapper;
using Corso.Service.DTOs.AulaDTOs;
using Corso.Service.DTOs.CorsoDTOs;
using Corso.Service.DTOs.DocenteDTOs;
using Corso.Service.DTOs.Studente_DTOs;
using Corso.WebApi.Models.AulaModels;
using Corso.WebApi.Models.CorsoModels;
using Corso.WebApi.Models.DocenteModels;
using Corso.WebApi.Models.StudenteModels;

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

            CreateMap<CreaDocenteModel, CreaDocenteDTO>();
            CreateMap<ModificaDocenteModel, ModificaDocenteDTO>();

            #endregion
            #region
            CreateMap<CreaStudenteModel, CreaStudenteDTO>();
            CreateMap<ModificaStudenteModel, ModificaStudenteDTO>();

            #endregion
            #region
            CreateMap<CreaCorsoModel, CreaCorsoDTO>();
            CreateMap<ModificaCorsoModel, ModificaCorsoDTO>();

            #endregion


        }
    }
}
