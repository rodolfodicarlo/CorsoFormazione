using AutoMapper;
using Corso.Entity.DAL;
using Corso.Service.DTOs.AulaDTOs;
using Corso.Service.DTOs.CorsoDTOs;
using Corso.Service.DTOs.DocenteDTOs;
using Corso.Service.DTOs.Studente_DTOs;

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

            #region Docente
            CreateMap<CreaDocenteDTO, Docente>();
            CreateMap<ModificaDocenteDTO, Docente>();
            CreateMap<Docente, DocenteDTO>();
            #endregion
            #region Studente
            CreateMap<CreaStudenteDTO, Docente>();
            CreateMap<ModificaStudenteDTO, Docente>();
            CreateMap<Docente, DocenteDTO>();
            #endregion
            #region Corso
            CreateMap<CreaCorsoDTO, CorsoEntity>()
             .ForMember(dest => dest.IDAula, opt => opt.MapFrom(src => src.Aula.IdAula))
             .ForMember(dest => dest.IDDocente, opt => opt.MapFrom(src => src.Docente.IDDocente));         
            CreateMap<ModificaCorsoDTO, CorsoEntity>();
            CreateMap<CorsoEntity, CorsoDTO>()
             .ForMember(dest => dest.Aula.IdAula, opt => opt.MapFrom(src => new AulaDTO() { IdAula=src.IDAula}))
             .ForMember(dest => dest.Docente.IDDocente, opt => opt.MapFrom(src => new DocenteDTO() { IDDocente=src.IDDocente}));

            #endregion
        }
    }
}
