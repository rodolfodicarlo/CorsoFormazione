using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.AulaDTOs
{
    /// <summary>
    /// Rappresenta il DTO per creare un'aula.
    /// </summary>
    public class CreaAulaDTO
    {
        /// <summary>
        /// Descrizione dell'aula.
        /// </summary>
        public string Descrizione { get; set; } = null!;

        /// <summary>
        /// Numero di posti disponibili nell'aula.
        /// </summary>
        public int NumeroPosti { get; set; } 
    }
}
