using AutoMapper;
using Corso.Entity.DAL;
using Corso.Entity.IUnitOfWork;
using Corso.Service.DTOs.StudenteDTOs;
using Corso.Service.IServices;
using MiddlewareExceptionHandler.ExceptionConfiguration;

namespace Corso.Service.Services
{
    /// <summary>
    /// Servizio per la gestione delle operazioni relative all'entità Studente
    /// </summary>
    public class StudenteService : IStudenteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Costruttore del servizio Studente
        /// </summary>
        /// <param name="unitOfWork">Unità di lavoro per la gestione delle transazioni</param>
        /// <param name="mapper">Mapper per la transformazione dei modelli</param>
        public StudenteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<List<StudenteDTO>> GetAll()
        {
            try
            {
                List<Studente> listaStudenti = (await _unitOfWork.StudenteRepository.GetAll()).ToList();
                List<StudenteDTO> listaStudenteDTO = _mapper.Map<List<StudenteDTO>>(listaStudenti);
                return listaStudenteDTO;
            }
            catch
            {
                throw;
            }
        }
        /// <inheritdoc/>
        public async Task<StudenteDTO> GetById(int id)
        {
            try
            {
                Studente studente = (await _unitOfWork.StudenteRepository.Get(a => a.IDStudente == id)).FirstOrDefault() ?? throw new BadRequestException("IDStudente errato o inesistente", "Ops... Qualcosa è andato storto");
                StudenteDTO studenteDTO = _mapper.Map<StudenteDTO>(studente);
                return studenteDTO;
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<StudenteDTO> Create(CreaStudenteDTO dto)
        {
            try
            {
                Studente studente = _mapper.Map<Studente>(dto);
                studente = await _unitOfWork.StudenteRepository.Insert(studente);
                await _unitOfWork.StudenteRepository.Save();
                StudenteDTO studenteDTO = _mapper.Map<StudenteDTO>(studente);
                return studenteDTO;
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<StudenteDTO> Update(ModificaStudenteDTO dto)
        {
            try
            {
                Studente studente = await _unitOfWork.StudenteRepository.GetByID(dto.IDStudente) ?? throw new BadRequestException(message: "IDStudente errato o inesistente");
                _mapper.Map(dto, studente);
                await _unitOfWork.StudenteRepository.Save();
                StudenteDTO studenteDTO = _mapper.Map<StudenteDTO>(studente);
                return studenteDTO;
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
                Studente studente = await _unitOfWork.StudenteRepository.GetByID(id) ?? throw new BadRequestException(message: "IDStudente errato o inesistente.");
                _unitOfWork.StudenteRepository.Delete(studente);
                await _unitOfWork.StudenteRepository.Save();
                return studente.IDStudente;
            }
            catch
            {
                throw;
            }
        }
    }
}
