using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.StudenteDTOs
{
    /// <summary>
    /// Rappresenta i dati di uno studente
    /// </summary>
    public class StudenteDTO
    {
        /// <summary>
        /// Identificativo univoco dello studente
        /// </summary>
        public int IDStudente { get; set; }

        /// <summary>
        /// Cognome dello studente
        /// </summary>
        public string Cognome { get; set; } = null!;

        /// <summary>
        /// Nome dello studente
        /// </summary>
        public string Nome { get; set; } = null!;

        /// <summary>
        /// Matricola univoco dello studente
        /// </summary>
        public string Matricola { get; set; } = null!;
    }
}
