using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using AutoMapper;
using Corso.Entity.DAL;
using Corso.Entity.IUnitOfWork;
using Corso.Service.DTOs.AulaDTOs;
using Corso.Service.DTOs.CorsoDTOs;
using Corso.Service.IServices;
using MiddlewareExceptionHandler.ExceptionConfiguration;

namespace Corso.Service.Services
{
    /// <summary>
    /// Servizio per la gestione delle operazioni relative all'entità Corso.
    /// </summary>
    public class CorsoService : ICorsoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Costruttore del servizio Corso.
        /// </summary>
        /// <param name="unitOfWork">Unità di lavoro per la gestione delle transazioni.</param>
        /// <param name="mapper">Mapper per la trasformazione dei modelli.</param>
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
                List<Entity.DAL.Corso> listaCorsi = (await _unitOfWork.CorsoRepository.GetAll()).ToList();
                List<CorsoDTO> listaCorsoDTO = _mapper.Map<List<CorsoDTO>>(listaCorsi);
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
                Entity.DAL.Corso corso = (await _unitOfWork.CorsoRepository.Get(a => a.IDCorso == id)).FirstOrDefault() ?? throw new BadRequestException("IDCorso errato o inesistente", "Ops... Qualcosa è andato storto");
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
                Entity.DAL.Corso corso = await _unitOfWork.CorsoRepository.GetByID(dto.IDCorso) ?? throw new BadRequestException(message: "IDCorso errato o inesistente.");
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
                Entity.DAL.Corso corso = await _unitOfWork.CorsoRepository.GetByID(id) ?? throw new BadRequestException(message: "IDCorso errato o inesistente.");
                _unitOfWork.CorsoRepository.Delete(corso);
                await _unitOfWork.CorsoRepository.Save();
                return corso.IDCorso;
            }
            catch
            {
                throw;
            }
        }
    }
}
