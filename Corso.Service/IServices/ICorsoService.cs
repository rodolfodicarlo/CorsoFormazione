using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Service.DTOs.CorsoDTOs;

namespace Corso.Service.IServices
{
    /// <summary>
    /// Interfaccia per il servizio che gestisce le operazioni relative all'entità Corso.
    /// </summary>
    public interface ICorsoService
    {
        /// <summary>
        /// Recupera tutti i record di CorsoDTO.
        /// </summary>
        /// <returns>Una lista di oggetti CorsoDTO.</returns>
        Task<List<CorsoDTO>> GetAll();

        /// <summary>
        /// Recupera un record specifico di CorsoDTO mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore univoco del CorsoDTO da recuperare.</param>
        /// <returns>L'oggetto CorsoDTO con l'identificatore specificato.</returns>
        Task<CorsoDTO> GetById(int id);

        /// <summary>
        /// Crea un nuovo record di CorsoDTO.
        /// </summary>
        /// <param name="dto">L'oggetto CreaCorsoDTO per creare un nuovo CorsoDTO.</param>
        /// <returns>Il nuovo oggetto CorsoDTO creato.</returns>
        Task<CorsoDTO> Create(CreaCorsoDTO dto);

        /// <summary>
        /// Aggiorna un record esistente di CorsoDTO.
        /// </summary>
        /// <param name="dto">L'oggetto ModificaCorsoDTO aggiornato per il CorsoDTO.</param>
        /// <returns>L'oggetto CorsoDTO aggiornato.</returns>
        Task<CorsoDTO> Update(ModificaCorsoDTO dto);

        /// <summary>
        /// Elimina un record specifico di CorsoDTO mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore univoco del CorsoDTO da eliminare.</param>
        /// <returns>L'identificatore univoco del CorsoDTO eliminato.</returns>
        Task<int> Delete(int id);
    }
}
