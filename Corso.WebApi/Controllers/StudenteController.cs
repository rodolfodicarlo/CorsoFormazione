using System.Net;
using AutoMapper;
using Corso.Service.DTOs.AulaDTOs;
using Corso.Service.DTOs.StudenteDTOs;
using Corso.Service.IServices;
using Corso.Service.Services;
using Corso.WebApi.Models.AulaModels;
using Corso.WebApi.Models.StudenteModels;
using Microsoft.AspNetCore.Mvc;
using MiddlewareExceptionHandler.Controllers;
using MiddlewareExceptionHandler.ResponseModel;

namespace Corso.WebApi.Controllers
{
    /// <summary>
    /// Controller per la gestione delle operazioni relative all'entità Studente.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudenteController : BaseApiController
    {
        private readonly IStudenteService _studenteService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Costruttore del controller Studente.
        /// </summary>
        /// <param name="studenteService">Servizio per la gestione degli studenti.</param>
        /// <param name="mapper">Mapper per la trasformazione dei modelli.</param>
        /// <param name="logger">Logger per la gestione dei log.</param>
        public StudenteController(IStudenteService studenteService, IMapper mapper, ILogger<StudenteController> logger) : base(logger)
        {
            _studenteService = studenteService;
            _mapper = mapper;
        }

        /// <summary>
        /// Recupera l'elenco di tutte gli studenti.
        /// </summary>
        /// <returns>Una lista di oggetti <see cref="StudenteDTO"/>.</returns>
        /// <response code="200">L'elenco di tutte gli studenti.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseModel<List<StudenteDTO>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ElencoStudenti()
        {
            try
            {
                List<StudenteDTO> elencoStudenti = await _studenteService.GetAll();
                return StandardMessageResult(HttpStatusCode.OK, result: elencoStudenti);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Recupera i dettagli di uno studente specifico per ID.
        /// </summary>
        /// <param name="id">L'ID dello studente da recuperare.</param>
        /// <returns>Un oggetto <see cref="StudenteDTO"/>.</returns>
        /// <response code="200">Uno studente specifico per ID..</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseModel<StudenteDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> RecuperaStudente(int id)
        {
            try
            {
                StudenteDTO studenteDTO = await _studenteService.GetById(id);
                return StandardMessageResult(HttpStatusCode.OK, result: studenteDTO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Crea un nuovo studente.
        /// </summary>
        /// <param name="model">Il modello contenente i dati per la creazione di un nuovo studente.</param>
        /// <returns>L'oggetto <see cref="StudenteDTO"/> creato.</returns>
        /// <response code="200">Lo studente creato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseModel<AulaDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreaStudente([FromBody] CreaStudenteModel model)
        {
            try
            {
                CreaStudenteDTO creaStudenteDTO = _mapper.Map<CreaStudenteDTO>(model);
                StudenteDTO studenteDTO = await _studenteService.Create(creaStudenteDTO);
                return StandardMessageResult(HttpStatusCode.OK, result: studenteDTO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica uno studente esistente.
        /// </summary>
        /// <param name="model">Il modello contenente i dati aggiornati dello studente.</param>
        /// <returns>L'oggetto <see cref="StudenteDTO"/> aggiornato.</returns>
        /// <response code="200">Lo studente modificato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponseModel<StudenteDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ModificaStudente([FromBody] ModificaStudenteDTO model)
        {
            try
            {
                ModificaStudenteDTO modificaStudenteDTO = _mapper.Map<ModificaStudenteDTO>(model);
                StudenteDTO studenteDTO = await _studenteService.Update(modificaStudenteDTO);
                return StandardMessageResult(HttpStatusCode.OK, result: studenteDTO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina uno studente specifico per ID.
        /// </summary>
        /// <param name="id">L'ID dello studente da eliminare.</param>
        /// <returns>L'ID dello studente eliminato.</returns>
        /// <response code="200">L'id dello studente eliminato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponseModel<int>), StatusCodes.Status200OK)]
        public async Task<ActionResult> EliminaStudente(int id)
        {
            try
            {
                int idDeleted = await _studenteService.Delete(id);
                return StandardMessageResult(HttpStatusCode.OK, result: idDeleted);
            }
            catch
            {
                throw;
            }
        }
    }
}
