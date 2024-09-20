using AutoMapper;
using Corso.Entity.DAL;
using Corso.Entity.IUnitOfWork;
using Corso.Service.DTOs.StudenteDTOs;
using Corso.Service.IServices;
using MiddlewareExceptionHandler.ExceptionConfiguration;

namespace Corso.Service.Services
{
    /// <summary>
    /// Servizio per la gestione delle operazione relative all'entità studente. 
    /// </summary>
    public class StudenteService : IStudenteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Costruttore del servizio studente.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
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
                List<Studente> listaStudente = (await _unitOfWork.StudenteRepository.GetAll()).ToList();
                List<StudenteDTO> listaStudenteDTO = _mapper.Map<List<StudenteDTO>>(listaStudente);
                return listaStudenteDTO;
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<StudenteDTO> GetById(Guid id)
        {
            try
            {
                Studente studente = (await _unitOfWork.StudenteRepository.Get(a => a.Idstudente == id)).FirstOrDefault() ?? throw new BadRequestException("IDStudente errato o inesistente", "Ops... Qualcosa è andato storto");
                StudenteDTO studenteDTO = _mapper.Map<StudenteDTO>(studente);
                return studenteDTO;
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdocs/>
        public async Task<StudenteDTO> Create(StudenteDTO dto)
        {
            try
            {
                Studente studente = _mapper.Map<Studente>(dto);
                studente.Matricola = Guid.NewGuid().ToString();
                //studente.Matricola = GeneraMatricola(); 
                studente = await _unitOfWork.StudenteRepository.Insert(studente);
                await _unitOfWork.StudenteRepository.Save();
                StudenteDTO studenteDTO = _mapper.Map<StudenteDTO>(studente);
                return studenteDTO;
            }
            catch /*(Exception ex)*/
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<StudenteDTO> Update(ModificaStudenteDTO dto)
        {
            try
            {
                Studente studente = await _unitOfWork.StudenteRepository.GetByID(dto.IDStudente) ?? throw new BadRequestException("IDStudente errato o inesistente", "Ops... qualcosa è andato storto");
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
        public async Task<Guid> Delete(Guid id)
        {
            try
            {
                Studente studente = await _unitOfWork.StudenteRepository.GetByID(id) ?? throw new BadImageFormatException("IDStudente errato o inesistente", "Ops... qualcosa è andato storto");
                _unitOfWork.StudenteRepository.Delete(studente);
                await _unitOfWork.StudenteRepository.Save();
                return studente.Idstudente;
            }
            catch
            {
                throw;
            }
        }

        //private string GeneraMatricola()
        //{
        //    string nuovaMatricola; 
        //    string ultimaMatricola = _unitOfWork.StudenteRepository.RecuperaUltimaMatricola();
        //    if (ultimaMatricola != null)
        //    {
        //        nuovaMatricola = (int.Parse(ultimaMatricola) + 1).ToString();
        //    }
        //    else
        //    {
        //        nuovaMatricola = "1";
        //    }
        //    return nuovaMatricola;
        //}
    }
}
