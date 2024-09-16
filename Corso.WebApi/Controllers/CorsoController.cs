using AutoMapper;
using Corso.Service.DTOs.CorsoDTOs;
using Corso.Service.IServices;
using Corso.WebApi.Models.CorsoModels;
using Microsoft.AspNetCore.Mvc;
using MiddlewareExceptionHandler.Controllers;
using MiddlewareExceptionHandler.ResponseModel;
using System.Net;

namespace Corso.WebApi.Controllers
{
    /// <summary>
    /// Controller per la gestione delle operazioni relative all'entità Corso.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class CorsoController : BaseApiController
    {
        private readonly ICorsoService _corsoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Costruttore del controller Corso.
        /// </summary>
        /// <param name="corsoService">Servizio per la gestione dei corsi.</param>
        /// <param name="mapper">Mapper per la trasformazione dei modelli.</param>
        /// <param name="logger">Logger per la gestione dei log.</param>
        public CorsoController(ICorsoService corsoService, IMapper mapper, ILogger<CorsoController> logger) : base(logger)
        {
            _corsoService = corsoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Recupera l'elenco di tutti i corsi.
        /// </summary>
        /// <returns>Una lista di oggetti <see cref="CorsoDTO"/>.</returns>
        /// <response code="200">L'elenco di tutti i corsi.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseModel<List<CorsoDTO>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ElencoCorsi()
        {
            try
            {
                List<CorsoDTO> elencoCorso = await _corsoService.GetAll();
                return StandardMessageResult(HttpStatusCode.OK, result: elencoCorso);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Recupera i dettagli di un corso specifico per ID.
        /// </summary>
        /// <param name="id">L'ID del corso da recuperare.</param>
        /// <returns>Un oggetto <see cref="CorsoDTO"/>.</returns>
        /// <response code="200">Un corso specifico per ID.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseModel<CorsoDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> RecuperaCorso(int id)
        {
            try
            {
                CorsoDTO corsoDTO = await _corsoService.GetById(id);
                return StandardMessageResult(HttpStatusCode.OK, result: corsoDTO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Crea un nuovo corso.
        /// </summary>
        /// <param name="model">Il modello contenente i dati per la creazione di un nuovo corso.</param>
        /// <returns>L'oggetto <see cref="CorsoDTO"/> creato.</returns>
        /// <response code="200">Il corso creato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseModel<CorsoDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreaCorso([FromBody] CreaCorsoModel model)
        {
            try
            {
                CreaCorsoDTO creaCorsoDTO = _mapper.Map<CreaCorsoDTO>(model);
                CorsoDTO corsoDTO = await _corsoService.Create(creaCorsoDTO);
                return StandardMessageResult(HttpStatusCode.OK, result: corsoDTO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica un corso.
        /// </summary>
        /// <param name="model">Il modello contenente i dati modificati del corso.</param>
        /// <returns>L'oggetto <see cref="CorsoDTO"/> modificato.</returns>
        /// <response code="200">Il corso modificato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponseModel<CorsoDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ModificaCorso([FromBody] ModificaCorsoModel model)
        {
            try
            {
                ModificaCorsoDTO modificaCorsoDTO = _mapper.Map<ModificaCorsoDTO>(model);
                CorsoDTO corsoDTO = await _corsoService.Update(modificaCorsoDTO);
                return StandardMessageResult(HttpStatusCode.OK, result: corsoDTO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina un corso.
        /// </summary>
        /// <param name="id">L'identificativo univoco del corso da eliminare.</param>
        /// <returns>L'ID del corso eliminato.</returns>
        /// <response code="200">L'ID del corso eliminato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponseModel<int>), StatusCodes.Status200OK)]
        public async Task<ActionResult> EliminaCorso(int id)
        {
            try
            {
                int idDeleted = await _corsoService.Delete(id);
                return StandardMessageResult(HttpStatusCode.OK, result: idDeleted);
            }
            catch
            {
                throw;
            }
        }
    }
}
