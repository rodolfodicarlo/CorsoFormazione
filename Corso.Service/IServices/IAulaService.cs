using Corso.Service.DTOs.AulaDTOs;

namespace Corso.Service.IServices
{
    /// <summary>
    /// Interfaccia per il servizio che gestisce le operazioni relative all'entità Aula.
    /// </summary>
    public interface IAulaService
    {
        /// <summary>
        /// Recupera tutti i record di AulaDTO.
        /// </summary>
        /// <returns>Una lista di oggetti AulaDTO.</returns>
        Task<List<AulaDTO>> GetAll();

        /// <summary>
        /// Recupera un record specifico di AulaDTO mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore univoco dell'AulaDTO da recuperare.</param>
        /// <returns>L'oggetto AulaDTO con l'identificatore specificato.</returns>
        Task<AulaDTO> GetById(int id);

        /// <summary>
        /// Crea un nuovo record di AulaDTO.
        /// </summary>
        /// <param name="dto">L'oggetto CreaAulaDTO per creare una nuova AulaDTO.</param>
        /// <returns>Il nuovo oggetto AulaDTO creato.</returns>
        Task<AulaDTO> Create(CreaAulaDTO dto);

        /// <summary>
        /// Aggiorna un record esistente di AulaDTO.
        /// </summary>
        /// <param name="dto">L'oggetto ModificaAulaDTO aggiornate per l'AulaDTO.</param>
        /// <returns>L'oggetto AulaDTO aggiornato.</returns>
        Task<AulaDTO> Update(ModificaAulaDTO dto);

        /// <summary>
        /// Elimina un record specifico di AulaDTO mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore univoco dell'AulaDTO da eliminare.</param>
        /// <returns>L'identificatore univoco dell'AulaDTO eliminato.</returns>
        Task<int> Delete(int id);
    }
}
