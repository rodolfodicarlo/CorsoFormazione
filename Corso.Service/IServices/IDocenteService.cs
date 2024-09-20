using Corso.Service.DTOs.DocenteDTOs;

namespace Corso.Service.IServices
{
    /// <summary>
    /// Interfaccia per il servizio che gestisce le operazioni relative all'entità docente.
    /// </summary>
    public interface IDocenteService
    {
        /// <summary>
        /// Recupera tutti i record di DocenteDto.
        /// </summary>
        /// <returns>Una lista di oggetti DocenteDto.</returns>
        Task<List<DocenteDTO>> GetAll();

        /// <summary>
        /// Recupera un record specifico di DocenteDto mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore del DocenteDTO da recuperare.</param>
        /// <returns>L'oggetto DocenteDto con l'identificatore specificato.</returns>
        Task<DocenteDTO> GetById(Guid id);

        /// <summary>
        /// Crea un nuovo record di DocenteDto.
        /// </summary>
        /// <param name="dto">L'oggetto CreaDocenteDTO per creare un nuovo DocenteDTO.</param>
        /// <returns>Il nuovo oggetto DocenteDTO creato.</returns>
        Task<DocenteDTO> Create(DocenteDTO dto);

        /// <summary>
        /// Aggiorna un record esistente di DocenteDTO.
        /// </summary>
        /// <param name="dto">L'oggetto ModificaDocenteDTO aggiornato per il DocenteDTO.</param>
        /// <returns>L'oggetto DocenteDTO aggiornato.</returns>
        Task<DocenteDTO> Update(ModificaDocenteDTO dto);
        /// <summary>
        /// Elimina un record specificato di DocenteDTO mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore univoco del DocenteDTO eliminato.</param>
        /// <returns></returns>
        Task<Guid> Delete(Guid id);

    }
}
