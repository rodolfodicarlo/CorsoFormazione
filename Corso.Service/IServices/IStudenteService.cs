using Corso.Service.DTOs.StudenteDTOs;

namespace Corso.Service.IServices
{
    /// <summary>
    /// Interfaccia per il servizio che gestisce le operazioni relative all'entità studente.
    /// </summary>
    public interface IStudenteService
    {
        /// <summary>
        /// Recupera tutti i record di StudenteDto.
        /// </summary>
        /// <returns>Una lista di oggetti StudenteDto.</returns>
        Task<List<StudenteDTO>> GetAll();

        /// <summary>
        /// Recupera un record specifico di StudenteDto mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore dello StudenteDTO da recuperare.</param>
        /// <returns>L'oggetto StudenteDto con l'identificatore specificato.</returns>
        Task<StudenteDTO> GetById(int id);

        /// <summary>
        /// Crea un nuovo record di StudenteDto.
        /// </summary>
        /// <param name="dto">L'oggetto CreaStudenteDTO per creare un nuovo StudenteDTO.</param>
        /// <returns>Il nuovo oggetto StudenteDTO creato.</returns>
        Task<StudenteDTO> Create(CreaStudenteDTO dto);

        /// <summary>
        /// Aggiorna un record esistente di StudenteDTO.
        /// </summary>
        /// <param name="dto">L'oggetto ModificaStudenteDTO aggiornato per lo StudenteDTO.</param>
        /// <returns>L'oggetto StudenteDTO aggiornato.</returns>
        Task<StudenteDTO> Update(ModificaStudenteDTO dto);
       
        /// <summary>
        /// Elimina un record specificato di StudenteDTO mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id">L'identificatore univoco dello StudenteDTO eliminato.</param>
        /// <returns></returns>
        Task<int> Delete(int id);
    }
}
