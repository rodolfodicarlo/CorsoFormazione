using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Service.DTOs.AulaDTOs;
using Corso.Service.DTOs.DocenteDTOs;

namespace Corso.Service.IServices
{
    /// <summary>
    /// Interfaccia per il servizio che gestisce le operazioni realative al docente
    /// </summary>
    public interface IDocenteService
    {
        /// <summary>
        /// Recupera tutti i record di DocenteDTO.
        /// </summary>
        /// <returns></returns>
        Task<List<DocenteDTO>> GetAll();
        /// <summary>
        /// Recupera un record specifico 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DocenteDTO> GetById(int id);
        /// <summary>
        /// Crea un nuovo record di docente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<DocenteDTO> Create(CreaDocenteDTO dto);
        /// <summary>
        /// Aggiorna un record esistente di DocenteDTO
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<DocenteDTO> Update(ModificaDocenteDTO dto);
        /// <summary>
        /// Elimina un record specifico di DocenteDTO mediante il suo identificatore univoco.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> Delete(int id);



    }
}
