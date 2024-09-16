using Corso.Service.DTOs.CorsoDTOs;

namespace Corso.Service.IServices
{
    /// <summary>
    /// Interfaccia per il servizio che gestisce le operazioni relative all'entità corso.
    /// </summary>
    public interface ICorsoService
    {
        /// <summary>
        /// Recupera tutti i record di CorsoDto.
        /// </summary>
        /// <returns>Una lista di oggetti CorsoDto.</returns>
        Task<List<CorsoDTO>> GetAll();

        /// <summary>
        /// Recupera un record specifico di CorsoDto mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore del CorsoDTO da recuperare.</param>
        /// <returns>L'oggetto CorsoDto con l'identificatore specificato.</returns>
        Task<CorsoDTO> GetById(int id);

        /// <summary>
        /// Crea un nuovo record di CorsoDto.
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
        /// Elimina un record specificato di CorsoDTO mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore univoco del CorsoDTO eliminato.</param>
        /// <returns></returns>
        Task<int> Delete(int id);
    }
}
