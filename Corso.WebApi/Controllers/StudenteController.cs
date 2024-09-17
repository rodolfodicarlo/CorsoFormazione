using AutoMapper;
using Corso.Service.DTOs.StudenteDTOs;
using Corso.Service.IServices;
using Corso.WebApi.Helpers.InjectableHelpers;
using Corso.WebApi.Models.StudenteModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiddlewareExceptionHandler.Controllers;
using MiddlewareExceptionHandler.ExceptionConfiguration;
using MiddlewareExceptionHandler.ResponseModel;
using System.Net;

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
        private readonly TokenHelper _tokenHelper;

        /// <summary>
        /// Costruttore del controller Studente.
        /// </summary>
        /// <param name="studenteService">Servizio per la gestione degli studenti.</param>
        /// <param name="mapper">Mapper per la trasformazione dei modelli.</param>
        /// <param name="logger">Logger per la gestione dei log.</param>
        public StudenteController(IStudenteService studenteService, IMapper mapper, TokenHelper tokenHelper, ILogger<StudenteController> logger) : base(logger)
        {
            _studenteService = studenteService;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        /// <summary>
        /// Recupera l'elenco di tutte le studente.
        /// </summary>
        /// <returns>Una lista di oggetti <see cref="StudenteDTO"/>.</returns>
        /// <response code="200">L'elenco di tutte le aule.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpGet]
        [Authorize(Roles = "Admin, Studente")]
        [ProducesResponseType(typeof(ApiResponseModel<List<StudenteDTO>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ElencoStudenti()
        {
            try
            {
                List<StudenteDTO> elencoStudente = await _studenteService.GetAll();
                return StandardMessageResult(System.Net.HttpStatusCode.OK, result: elencoStudente);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Recupera i dettagli di uno studente specifico per ID.
        /// </summary>
        /// <param name="id">L'ID del studente da recuperare.</param>
        /// <returns>Un oggetto <see cref="StudenteDTO"/>.</returns>
        /// <response code="200">Uno studente specifico per ID.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpGet]
        [Authorize(Roles = "Admin, Studente")]
        [ProducesResponseType(typeof(ApiResponseModel<StudenteDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> RecuperaStudente(int id)
        {
            try
            {
                if (_tokenHelper.IsAuthorized(["Admin"], id))
                {
                    StudenteDTO studenteDTO = await _studenteService.GetById(id);
                    return StandardMessageResult(HttpStatusCode.OK, result: studenteDTO);
                }
                else
                {
                    throw new CustomException("Unauthorized", HttpStatusCode.Unauthorized, "Ops... Qualcosa è andato storto");
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica un studente.
        /// </summary>
        /// <param name="model">Il modello contenente i dati modificati dello studente.</param>
        /// <returns>L'oggetto <see cref="StudenteDTO"/> modificato.</returns>
        /// <response code="200">Lo studente modificato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpPut]
        [Authorize(Roles = "Admin, Studente")]
        [ProducesResponseType(typeof(ApiResponseModel<StudenteDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ModificaStudente([FromBody] ModificaStudenteModel model)
        {
            try
            {
                if (_tokenHelper.IsAuthorized(["Admin"], model.IDStudente))
                {
                    ModificaStudenteDTO modificaStudenteDTO = _mapper.Map<ModificaStudenteDTO>(model);
                    StudenteDTO studenteDTO = await _studenteService.Update(modificaStudenteDTO);
                    return StandardMessageResult(HttpStatusCode.OK, result: studenteDTO);
                }
                else
                {
                    throw new CustomException("Unauthorized", HttpStatusCode.Unauthorized, "Ops... Qualcosa è andato storto");
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina uno studente.
        /// </summary>
        /// <param name="id">L'identificativo univoco del studente da eliminare.</param>
        /// <returns>L'ID del studente eliminato.</returns>
        /// <response code="200">L'ID dello studente eliminato.</response>
        /// <response code="400">BadRequest. L'attributo payload sarà null.</response>
        /// <response code="500">Server error. L'attributo payload sarà null.</response>
        [HttpDelete]
        [Authorize(Roles = "Admin, Studente")]
        [ProducesResponseType(typeof(ApiResponseModel<int>), StatusCodes.Status200OK)]
        public async Task<ActionResult> EliminaStudente(int id)
        {
            try
            {
                if (_tokenHelper.IsAuthorized(["Admin"], id))
                {
                    int idDeleted = await _studenteService.Delete(id);
                    return StandardMessageResult(HttpStatusCode.OK, result: idDeleted);
                }
                else
                {
                    throw new CustomException("Unauthorized", HttpStatusCode.Unauthorized, "Ops... Qualcosa è andato storto");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
