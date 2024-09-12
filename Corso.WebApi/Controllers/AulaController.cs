using AutoMapper;
using Corso.Service.DTOs.AulaDTOs;
using Corso.Service.IServices;
using Corso.WebApi.Models.AulaModels;
using Microsoft.AspNetCore.Mvc;
using MiddlewareExceptionHandler.Controllers;
using MiddlewareExceptionHandler.ResponseModel;
using System.Net;

namespace Corso.WebApi.Controllers
{
    /// <summary>
    /// Controller per la gestione delle operazioni relative all'entità Aula.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class AulaController : BaseApiController
    {
        private readonly IAulaService _aulaService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Costruttore del controller Aula.
        /// </summary>
        /// <param name="aulaService">Servizio per la gestione delle aule.</param>
        /// <param name="mapper">Mapper per la trasformazione dei modelli.</param>
        /// <param name="logger">Logger per la gestione dei log.</param>
        public AulaController(IAulaService aulaService, IMapper mapper, ILogger<AulaController> logger) : base(logger)
        {
            _aulaService = aulaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Recupera l'elenco di tutte le aule.
        /// </summary>
        /// <returns>Una lista di oggetti <see cref="AulaDTO"/>.</returns>
        /// <response code="200">L'elenco di tutte le aule.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseModel<List<AulaDTO>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ElencoAule()
        {
            try
            {
                List<AulaDTO> elencoAule = await _aulaService.GetAll();
                return StandardMessageResult(HttpStatusCode.OK, result: elencoAule);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Recupera i dettagli di un'aula specifica per ID.
        /// </summary>
        /// <param name="id">L'ID dell'aula da recuperare.</param>
        /// <returns>Un oggetto <see cref="AulaDTO"/>.</returns>
        /// <response code="200">Un'aula specifica per ID..</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseModel<AulaDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> RecuperaAula(int id)
        {
            try
            {
                AulaDTO aulaDTO = await _aulaService.GetById(id);
                return StandardMessageResult(HttpStatusCode.OK, result: aulaDTO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Crea una nuova aula.
        /// </summary>
        /// <param name="model">Il modello contenente i dati per la creazione di una nuova aula.</param>
        /// <returns>L'oggetto <see cref="AulaDTO"/> creato.</returns>
        /// <response code="200">L'aula creata.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseModel<AulaDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreaAula([FromBody] CreaAulaModel model)
        {
            try
            {
                CreaAulaDTO creaAulaDTO = _mapper.Map<CreaAulaDTO>(model);
                AulaDTO aulaDTO = await _aulaService.Create(creaAulaDTO);
                return StandardMessageResult(HttpStatusCode.OK, result: aulaDTO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica un'aula esistente.
        /// </summary>
        /// <param name="model">Il modello contenente i dati aggiornati dell'aula.</param>
        /// <returns>L'oggetto <see cref="AulaDTO"/> aggiornato.</returns>
        /// <response code="200">L'aula modificata.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponseModel<AulaDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ModificaAula([FromBody] ModificaAulaModel model)
        {
            try
            {
                ModificaAulaDTO modificaAulaDTO = _mapper.Map<ModificaAulaDTO>(model);
                AulaDTO aulaDTO = await _aulaService.Update(modificaAulaDTO);
                return StandardMessageResult(HttpStatusCode.OK, result: aulaDTO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina un'aula specifica per ID.
        /// </summary>
        /// <param name="id">L'ID dell'aula da eliminare.</param>
        /// <returns>L'ID dell'aula eliminata.</returns>
        /// <response code="200">L'id dell'aula eliminata.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponseModel<int>), StatusCodes.Status200OK)]
        public async Task<ActionResult> EliminaAula(int id)
        {
            try
            {
                int idDeleted = await _aulaService.Delete(id);
                return StandardMessageResult(HttpStatusCode.OK, result: idDeleted);
            }
            catch
            {
                throw;
            }
        }
    }
}
