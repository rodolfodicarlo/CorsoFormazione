using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.DocenteDTOs
{
    /// <summary>
    /// Rappresenta il DTO per creare un docente
    /// </summary>
    public class CreaDocenteDTO
    {
        /// <summary>
        /// Cognome del docente
        /// </summary>
        public string Cognome { get; set; } = null!;
        /// <summary>
        /// Nome del docente
        /// </summary>
        public string Nome { get; set; } = null!;
    }
}
