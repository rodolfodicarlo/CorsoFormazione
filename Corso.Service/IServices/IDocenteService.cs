using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Service.DTOs.DocenteDTOs;

namespace Corso.Service.IServices
{
    /// <summary>
    /// Interfaccia per il servizio che gestisce le operazioni relative all'entità Docente
    /// </summary>
    public interface IDocenteService
    {
        /// <summary>
        /// Recupera tutti i record di DocenteDTO
        /// </summary>
        /// <returns>Una lista di oggetti DocenteDTO</returns>
        Task<List<DocenteDTO>> GetAll();
        /// <summary>
        /// Recupera un record specifico di DocenteDTO mediante il suo identificatore univoco
        /// </summary>
        /// <param name="id">L'identificatore univoco del DocenteDTO da recuperare</param>
        /// <returns>L'oggetto DocenteDTO con l'identificatore specificato</returns>
        Task<DocenteDTO> GetByID(int id);
        /// <summary>
        /// Crea un nuovo record di DocenteDTO.
        /// </summary>
        /// <param name="dto">L'oggetto CreaDocenteDTO per la creare una nuova DocenteDTO.</param>
        /// <returns>Il nuovo oggetto DocenteDTO creato.</returns>
        Task<DocenteDTO> Create(CreaDocenteDTO dto);
        /// <summary>
        /// Aggiorna un record esistente di DocenteDTO.
        /// </summary>
        /// <param name="dto">L'oggetto ModificaDocenteDTO aggiornate per il DocenteDTO.</param>
        /// <returns>L'oggetto DocenteDTO aggiornato.</returns>
        Task<DocenteDTO> Update(ModificaDocenteDTO dto);
        /// <summary>
        /// Elimina un record specifico di DocenteDTO mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore univoco del DocenteDTO da eliminare.</param>
        /// <returns>L'identificatore univoco del DocenteDTO eliminato.</returns>
        Task<int> Delete(int id);
    }
}
