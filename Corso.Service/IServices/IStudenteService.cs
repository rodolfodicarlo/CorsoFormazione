using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Service.DTOs.AulaDTOs;
using Corso.Service.DTOs.Studente_DTOs;

namespace Corso.Service.IServices
{
    /// <summary>
    /// Interfaccia per il servizio che gestisce le operazioni relative all'entità studente.
    /// </summary>
    public interface IStudenteService
    {
        /// <summary>
        /// Recupera tutti i record di StudenteDTO.
        /// </summary>
        /// <returns>Una lista di oggetti StudenteDTO .</returns>
        Task<List<StudenteDTO>> GetAll();
        /// <summary>
        /// Recupera un record specifico di StudenteDTO mediante il suo identificativo univoco.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>L'oggetto StudenteDTO con l'identificatore specificato.</returns>
        Task<StudenteDTO> GetById(int id);
        /// <summary>
        /// Crea un nuovo record di StudenteDTO.
        /// </summary>
        /// <param name="dto">L'oggetto CreaStudenteDTo per creare un nuovo StudneteDTO </param>
        /// <returns>Il nuovo oggetto StudenteDTO creato.</returns>
        Task<StudenteDTO> Create(CreaStudenteDTO dto);
        /// <summary>
        /// Modifica un record esistente di StudenteDTO.
        /// </summary>
        /// <param name="dto">L'oggeto ModificaStudenteDTO aggiornato per StudenteDTO </param>
        /// <returns>L'oggetto studenteDTO aggiornato</returns>
        Task<StudenteDTO> Update(ModificaStudenteDTO dto);
        /// <summary>
        /// Elimina un record di StudenteDTO mediante il suo identificativo univoco.
        /// </summary>
        /// <param name="id">L'identificatore univoco dello StudenteDTO da eliminare .</param>
        /// <returns>Identificatore univoco dello StudenteDTO eliminato .</returns>
        Task<int> Delete(int id);
    }
}
