using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Corso.Entity.DAL;
using Corso.Entity.IRepositories;
using Corso.Entity.IUnitOfWork;
using Corso.Service.DTOs.AulaDTOs;
using Corso.Service.DTOs.CorsoDTOs;
using Corso.Service.IServices;
using MiddlewareExceptionHandler.ExceptionConfiguration;

namespace Corso.Service.Services
{
    /// <summary>
    /// Servizio che gestisce le operazioni relative all'entità Corso.
    /// </summary>
    public class CorsoService : ICorsoService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        /// <summary>
        /// Costruttore del servizio corso
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
                List<CorsoEntity> listaCorsi = (await _unitOfWork.CorsoRepository.Get(includeProperties: ["Aula","Docente"])).ToList();
                List<CorsoDTO> listaCorsiDTO = _mapper.Map<List<CorsoDTO>>(listaCorsi);
                return listaCorsiDTO;
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
                CorsoEntity corso = (await _unitOfWork.CorsoRepository.Get(a => a.IDCorso == id)).FirstOrDefault() ?? throw new BadRequestException("IDCorso errato o inesistente", "Ops... Qualcosa è andato storto");
                CorsoDTO corsoDTO = _mapper.Map<CorsoDTO>(corso);
                return corsoDTO;
            }
            catch
            {
                throw;
            }
        }
        /// <inheritdoc/>
        public async Task<CorsoDTO> Create(CreaCorsoDTO dto)
        {
            try
            {
                _ = (await _unitOfWork.AulaRepository.Get(e => e.Idaula == dto.IDAula)).FirstOrDefault() ?? throw new BadRequestException("IDAula errato o inesistente", "Ops...qualcosa è andato storto");
                _ = (await _unitOfWork.DocenteRepository.Get(e => e.IDDocente == dto.IDDocente)).FirstOrDefault() ?? throw new BadRequestException("IDDocente errato o inesistente", "Ops...qualcosa è andato storto");
                CorsoEntity corso = _mapper.Map<CorsoEntity>(dto);
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
                CorsoEntity corso = await _unitOfWork.CorsoRepository.GetByID(dto.IDCorso) ?? throw new BadRequestException(message: "IDCorso errato o inesistente.");
                _mapper.Map(dto, corso);
                await _unitOfWork.AulaRepository.Save();
                CorsoDTO CorsoDTO = _mapper.Map<CorsoDTO>(corso);
                return CorsoDTO;
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
                CorsoEntity corso = await _unitOfWork.CorsoRepository.GetByID(id) ?? throw new BadRequestException(message: "IDCorso errato o inesistente.");
                _unitOfWork.CorsoRepository.Delete(corso);
                await _unitOfWork.AulaRepository.Save();
                return corso.IDCorso;
            }
            catch
            {
                throw;
            }
        }

    }
}
