using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.AulaDTOs
{
    /// <summary>
    /// Rappresenta i dati di un'aula.
    /// </summary>
    public class AulaDTO
    {
        /// <summary>
        /// Identificativo univoco dell'aula.
        /// </summary>
        public int IdAula { get; set; }

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
