using System.Net;
using AutoMapper;
using Corso.Service.DTOs.DocenteDTOs;
using Corso.Service.IServices;
using Corso.WebApi.Models.DocenteModels;
using Microsoft.AspNetCore.Mvc;
using MiddlewareExceptionHandler.Controllers;
using MiddlewareExceptionHandler.ResponseModel;

namespace Corso.WebApi.Controllers
{
    /// <summary>
    /// Controller per la gestione delle operazioni relative allientità Docente.
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
        [ProducesResponseType(typeof(ApiResponseModel<List<DocenteDTO>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ElencoDocenti()
        {
            try
            {
                List<DocenteDTO> elencoDocenti = await _docenteService.GetAll();
                return StandardMessageResult(HttpStatusCode.OK, result: elencoDocenti);
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
        /// <response code="200">Un docente specifico per ID..</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseModel<DocenteDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> RecuperaDocente(int id)
        {
            try
            {
                DocenteDTO docenteDTO = await _docenteService.GetByID(id);
                return StandardMessageResult(HttpStatusCode.OK, result: docenteDTO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Crea un nuova docente.
        /// </summary>
        /// <param name="model">Il modello contenente i dati per la creazione di un nuovo docente .</param>
        /// <returns>L'oggetto <see cref="DocenteDTO"/> creato.</returns>
        /// <response code="200">Il docente creato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseModel<DocenteDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreaDocente([FromBody] CreaDocenteModel model)
        {
            try
            {
                CreaDocenteDTO creaDocenteDTO = _mapper.Map<CreaDocenteDTO>(model);
                DocenteDTO docenteDTO = await _docenteService.Create(creaDocenteDTO);
                return StandardMessageResult(HttpStatusCode.OK, result: docenteDTO);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Modifica un docente esistente.
        /// </summary>
        /// <param name="model">Il modello contenente i dati aggiornati del docente.</param>
        /// <returns>L'oggetto <see cref="DocenteDTO"/> aggiornato.</returns>
        /// <response code="200">Il docente modificato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPut]
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
        /// Elimina un docente specifica per ID.
        /// </summary>
        /// <param name="id">L'ID del docente da eliminare.</param>
        /// <returns>L'ID del docente eliminato.</returns>
        /// <response code="200">L'id del docente eliminato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponseModel<int>), StatusCodes.Status200OK)]
        public async Task<ActionResult> EliminaDocente(int id)
        {
            try
            {
                int idDeleted = await _docenteService.Delete(id);
                return StandardMessageResult(HttpStatusCode.OK, result: idDeleted);
            }
            catch
            {
                throw;
            }
        }
    }
}
