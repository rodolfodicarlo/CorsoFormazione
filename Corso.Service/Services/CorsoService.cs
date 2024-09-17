using AutoMapper;
using Corso.Entity.IUnitOfWork;
using Corso.Service.DTOs.CorsoDTOs;
using Corso.Service.IServices;
using MiddlewareExceptionHandler.ExceptionConfiguration;

namespace Corso.Service.Services
{
    /// <summary>
    /// Servizio per la gestione delle operazioni relative all'entità corso.
    /// </summary>
    public class CorsoService : ICorsoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Costruttore del servizio corso.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public CorsoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<CorsoDTO>> GetAll()
        {
            try
            {
                List<Entity.DAL.Corso> listaCorso = (await _unitOfWork.CorsoRepository.Get(includeProperties: ["Docente", "Aula"])).ToList();
                List<CorsoDTO> listaCorsoDTO = _mapper.Map<List<CorsoDTO>>(listaCorso);
                return listaCorsoDTO;
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<CorsoDTO> GetById(int id)
        {
            try
            {
                Entity.DAL.Corso corso = (await _unitOfWork.CorsoRepository.Get(a => a.Idcorso == id)).FirstOrDefault() ?? throw new BadRequestException("IDCorso errato o inesistente", "Ops... Qualcosa è andato storto");
                CorsoDTO corsoDTO = _mapper.Map<CorsoDTO>(corso);
                return corsoDTO;
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdocs/>
        public async Task<CorsoDTO> Create(CreaCorsoDTO dto)
        {
            try
            {
                _ = (await _unitOfWork.AulaRepository.Get(a => a.Idaula == dto.IdAula)).FirstOrDefault() ?? throw new BadRequestException("IdAula errata o inesistente", "Ops, qualcosa è andato storto");
                _ = (await _unitOfWork.DocenteRepository.Get(d => d.Iddocente == dto.IdDocente)).FirstOrDefault() ?? throw new BadRequestException("IdDocente errato o inesistente", "Ops, qualcosa è andato storto");
                Entity.DAL.Corso corso = _mapper.Map<Entity.DAL.Corso>(dto);
                corso = await _unitOfWork.CorsoRepository.Insert(corso);
                await _unitOfWork.CorsoRepository.Save();
                CorsoDTO corsoDTO = _mapper.Map<CorsoDTO>(corso);
                return corsoDTO;
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<CorsoDTO> Update(ModificaCorsoDTO dto)
        {
            try
            {
                _ = (await _unitOfWork.AulaRepository.Get(a => a.Idaula == dto.IdAula)).FirstOrDefault() ?? throw new BadRequestException("IdAula errata o inesistente", "Ops, qualcosa è andato storto");
                _ = (await _unitOfWork.DocenteRepository.Get(d => d.Iddocente == dto.IdDocente)).FirstOrDefault() ?? throw new BadRequestException("IdDocente errato o inesistente", "Ops, qualcosa è andato storto");
                Entity.DAL.Corso corso = await _unitOfWork.CorsoRepository.GetByID(dto.IdCorso) ?? throw new BadRequestException("IDCorso errato o inesistente", "Ops... qualcosa è andato storto");
                _mapper.Map(dto, corso);
                await _unitOfWork.CorsoRepository.Save();
                CorsoDTO corsoDTO = _mapper.Map<CorsoDTO>(corso);
                return corsoDTO;
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
                Entity.DAL.Corso corso = await _unitOfWork.CorsoRepository.GetByID(id) ?? throw new BadImageFormatException("IDCorso errato o inesistente", "Ops... qualcosa è andato storto");
                _unitOfWork.CorsoRepository.Delete(corso);
                await _unitOfWork.CorsoRepository.Save();
                return corso.Idcorso;
            }
            catch
            {
                throw;
            }
        }
    }
}
