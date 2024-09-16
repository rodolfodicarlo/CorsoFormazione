using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Service.DTOs.StudenteDTOs;

namespace Corso.Service.IServices
{
    /// <summary>
    /// Interfaccia per il servizio che gestisce le operazioni relative all'entità Studente.
    /// </summary>
    public interface IStudenteService
    {
        /// <summary>
        /// Recupera tutti i record di StudenteDTO.
        /// </summary>
        /// <returns>Una lista di oggetti StudenteDTO.</returns>
        Task<List<StudenteDTO>> GetAll();

        /// <summary>
        /// Recupera un record specifico di StudenteDTO mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore univoco dello StudenteDTO da recuperare.</param>
        /// <returns>L'oggetto StudenteDTO con l'identificatore specificato.</returns>
        Task<StudenteDTO> GetById(int id);

        /// <summary>
        /// Crea un nuovo record di StudenteDTO.
        /// </summary>
        /// <param name="dto">L'oggetto CreaStudenteDTO per creare un nuovo StudenteDTO.</param>
        /// <returns>Il nuovo oggetto StudenteDTO creato.</returns>
        Task<StudenteDTO> Create(CreaStudenteDTO dto);

        /// <summary>
        /// Aggiorna un record esistente di StudenteDTO.
        /// </summary>
        /// <param name="dto">L'oggetto ModificaStudenteDTO aggiornate per lo StudenteDTO.</param>
        /// <returns>L'oggetto StudenteDTO aggiornato.</returns>
        Task<StudenteDTO> Update(ModificaStudenteDTO dto);

        /// <summary>
        /// Elimina un record specifico di StudenteDTO mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore univoco dello StudenteDTO da eliminare.</param>
        /// <returns>L'identificatore univoco dello StudenteDTO eliminato.</returns>
        Task<int> Delete(int id);
    }
}
