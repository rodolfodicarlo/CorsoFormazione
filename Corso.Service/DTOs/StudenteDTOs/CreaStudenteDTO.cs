using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.Studente_DTOs
{
    /// <summary>
    /// Rappresenta il DTO per creare lo studente
    /// </summary>
    public class CreaStudenteDTO
    {
        /// <summary>
        /// Cognome dello studente
        /// </summary>
        public string Cognome { get; set; } = null!;
        /// <summary>
        /// Nome dello studente
        /// </summary>
        public string Nome { get; set; } = null!;
        /// <summary>
        /// Maricola identificativa dello studente
        /// </summary>
        public string Matricola { get; set; } = null!;
    }
}
