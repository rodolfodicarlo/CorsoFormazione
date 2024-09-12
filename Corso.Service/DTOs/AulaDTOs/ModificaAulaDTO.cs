using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.AulaDTOs
{
    /// <summary>
    /// Rappresenta il DTO per modificare un'aula.
    /// </summary>
    public class ModificaAulaDTO : CreaAulaDTO
    {
        /// <summary>
        /// Identificativo univoco dell'aula.
        /// </summary>
        public int IdAula { get; set; }
    }
}
