using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.DocenteDTOs
{
    /// <summary>
    /// Rappresenta i dati del docente
    /// </summary>
    public class DocenteDTO
    {
        /// <summary>
        /// Identificativo univoco del docente
        /// </summary>
        public int IDDocente { get; set; }
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
