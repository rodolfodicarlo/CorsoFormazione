using AutoMapper;
using Corso.Service.DTOs.DocenteDTOs;
using Corso.Service.IServices;
using Corso.WebApi.Models.DocenteModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiddlewareExceptionHandler.Controllers;
using MiddlewareExceptionHandler.ResponseModel;
using System.Net;

namespace Corso.WebApi.Controllers
{
    /// <summary>
    /// Controller per la gestione delle operazioni relative all'entità Docente.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class DocenteController : BaseApiController
    {
        private readonly IDocenteService _docenteService;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// Costruttore del controller Docente.
        /// </summary>
        /// <param name="docenteService">Servizio per la gestione dei docenti.</param>
        /// <param name="mapper">Mapper per la trasformazione dei modelli.</param>
        /// <param name="logger">Logger per la gestione dei log.</param>
        public DocenteController(IDocenteService docenteService, IMapper mapper, ILogger<DocenteController> logger) : base(logger)
        {
            _docenteService = docenteService;
            _mapper = mapper;
        }

        /// <summary>
        /// Recupera l'elenco di tutti i docenti.
        /// </summary>
        /// <returns>Una lista di oggetti <see cref="DocenteDTO"/>.</returns>
        /// <response code="200">L'elenco di tutti i docenti.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpGet]
        [Authorize(Roles = "Admin, Docente")]
        [ProducesResponseType(typeof(ApiResponseModel<List<DocenteDTO>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ElencoDocenti()
        {
            try
            {
                List<DocenteDTO> elencoDocente = await _docenteService.GetAll();
                return StandardMessageResult(HttpStatusCode.OK, result: elencoDocente);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Recupera i dettagli di un docente specifico per ID.
        /// </summary>
        /// <param name="id">L'ID del docente da recuperare.</param>
        /// <returns>Un oggetto <see cref="DocenteDTO"/>.</returns>
        /// <response code="200">Un docente specifico per ID.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpGet]
        [Authorize(Roles = "Admin, Docente")]
        [ProducesResponseType(typeof(ApiResponseModel<DocenteDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> RecuperaDocente(Guid id)
        {
            try
            {
                DocenteDTO docenteDTO = await _docenteService.GetById(id);
                return StandardMessageResult(HttpStatusCode.OK, result: docenteDTO);
            }
            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Modifica un docente.
        /// </summary>
        /// <param name="model">Il modello contenente i dati modificati del docente.</param>
        /// <returns>L'oggetto <see cref="DocenteDTO"/> modificato.</returns>
        /// <response code="200">Il docente modificato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPut]
        [Authorize(Roles = "Admin, Docente")]
        [ProducesResponseType(typeof(ApiResponseModel<DocenteDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ModificaDocente([FromBody] ModificaDocenteModel model)
        {
            try
            {
                ModificaDocenteDTO modificaDocenteDTO = _mapper.Map<ModificaDocenteDTO>(model);
                DocenteDTO docenteDTO = await _docenteService.Update(modificaDocenteDTO);
                return StandardMessageResult(HttpStatusCode.OK, result: docenteDTO);
            }
            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Elimina un docente.
        /// </summary>
        /// <param name="id">L'identificativo univoco del docente da eliminare.</param>
        /// <returns>L'ID del docente eliminato.</returns>
        /// <response code="200">L'ID del docente eliminato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpDelete]
        [Authorize(Roles = "Admin, Docente")]
        [ProducesResponseType(typeof(ApiResponseModel<Guid>), StatusCodes.Status200OK)]
        public async Task<ActionResult> EliminaDocente(Guid id)
        {
            try
            {
                Guid idDeleted = await _docenteService.Delete(id);
                return StandardMessageResult(HttpStatusCode.OK, result: idDeleted);
            }
            catch
            {
                throw;
            }
        }

    }
}
