using AutoMapper;
using Corso.Entity.DAL;
using Corso.Entity.IUnitOfWork;
using Corso.Service.DTOs.AulaDTOs;
using Corso.Service.IServices;
using MiddlewareExceptionHandler.ExceptionConfiguration;

namespace Corso.Service.Services
{
    /// <summary>
    /// Servizio per la gestione delle operazioni relative all'entità Aula.
    /// </summary>
    public class AulaService : IAulaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Costruttore del servizio Aula.
        /// </summary>
        /// <param name="unitOfWork">Unità di lavoro per la gestione delle transazioni.</param>
        /// <param name="mapper">Mapper per la trasformazione dei modelli.</param>
        public AulaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<AulaDTO>> GetAll()
        {
            try
            {
                List<Aula> listaAula = (await _unitOfWork.AulaRepository.GetAll()).ToList();
                List<AulaDTO> listaAulaDTO = _mapper.Map<List<AulaDTO>>(listaAula);
                return listaAulaDTO;
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<AulaDTO> GetById(int id)
        {
            try
            {
                Aula aula = (await _unitOfWork.AulaRepository.Get(a => a.Idaula == id)).FirstOrDefault() ?? throw new BadRequestException("IDAula errato o inesistente", "Ops... Qualcosa è andato storto");
                AulaDTO aulaDTO = _mapper.Map<AulaDTO>(aula);
                return aulaDTO;
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<AulaDTO> Create(CreaAulaDTO dto)
        {
            try
            {
                Aula aula = _mapper.Map<Aula>(dto);
                aula = await _unitOfWork.AulaRepository.Insert(aula);
                await _unitOfWork.AulaRepository.Save();
                AulaDTO aulaDTO = _mapper.Map<AulaDTO>(aula);
                return aulaDTO;
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<AulaDTO> Update(ModificaAulaDTO dto)
        {
            try
            {
                Aula aula = await _unitOfWork.AulaRepository.GetByID(dto.IdAula) ?? throw new BadRequestException(message: "IDAula errato o inesistente.");
                _mapper.Map(dto, aula);
                await _unitOfWork.AulaRepository.Save();
                AulaDTO aulaDTO = _mapper.Map<AulaDTO>(aula);
                return aulaDTO;
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<int> Delete(int id)
        {
            try
            {
                Aula aula = await _unitOfWork.AulaRepository.GetByID(id) ?? throw new BadRequestException(message: "IDAula errato o inesistente.");
                _unitOfWork.AulaRepository.Delete(aula);
                await _unitOfWork.AulaRepository.Save();
                return aula.Idaula;
            }
            catch
            {
                throw;
            }
        }
    }
}
