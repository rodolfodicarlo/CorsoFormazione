﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Corso.Entity.DAL;
using Corso.Entity.IUnitOfWork;
using Corso.Service.DTOs.DocenteDTOs;
using Corso.Service.IServices;
using MiddlewareExceptionHandler.ExceptionConfiguration;

namespace Corso.Service.Services
{
    /// <summary>
    /// Servizio per la gestione delle operazioni relative dell'entità docente. 
    /// </summary>
    public class DocenteService : IDocenteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        /// <summary>
        /// Costruttore del servizio Docente
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public DocenteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<List<DocenteDTO>> GetAll()
        {
            try
            {
                List<Docente> listaDocenti = (await _unitOfWork.DocenteRepository.GetAll()).ToList();
                List<DocenteDTO> listaDocentiDTO = _mapper.Map<List<DocenteDTO>>(listaDocenti);
                return listaDocentiDTO;
            }
            catch
            {
                throw;
            }
        }
        /// <inheritdoc/>
        public async Task<DocenteDTO> GetById(int id)
        {
            try
            {
                Docente docente = (await _unitOfWork.DocenteRepository.Get(a => a.IDDocente == id)).FirstOrDefault() ?? throw new BadRequestException("IDAula errato o inesistente", "Ops... Qualcosa è andato storto");
                DocenteDTO docenteDTO = _mapper.Map<DocenteDTO>(docente);
                return docenteDTO;
            }
            catch
            {
                throw;
            }
        }
        /// <inheritdoc/>
        public async Task<DocenteDTO> Create(CreaDocenteDTO dto)
        {
            try
            {
                Docente docente = _mapper.Map<Docente>(dto);
                docente = await _unitOfWork.DocenteRepository.Insert(docente);
                await _unitOfWork.DocenteRepository.Save();
                DocenteDTO docenteDTO = _mapper.Map<DocenteDTO>(docente);
                return docenteDTO;
            }
            catch
            {
                throw;
            }
            
        }
        /// <inheritdoc/>
        public async Task<DocenteDTO> Update(ModificaDocenteDTO dto)
        {
            try
            {
                Docente docente = await _unitOfWork.DocenteRepository.GetByID(dto.IDDocente) ?? throw new BadRequestException(message: "IDDocente errato o inesistente");
                _mapper.Map(dto, docente);
                await _unitOfWork.DocenteRepository.Save();
                DocenteDTO docenteDTO = _mapper.Map<DocenteDTO>(docente);
                return docenteDTO;
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
                Docente docente = await _unitOfWork.DocenteRepository.GetByID(id) ?? throw new BadRequestException(message: "IDDocente errato o inesistente. ");
                _unitOfWork.DocenteRepository.Delete(docente);
                await _unitOfWork.DocenteRepository.Save();
                return docente.IDDocente;
            }
            catch
            {
                throw;
            }
        }

    }
}
