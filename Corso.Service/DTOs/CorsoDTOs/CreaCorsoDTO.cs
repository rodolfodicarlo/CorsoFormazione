using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.CorsoDTOs
{
    /// <summary>
    /// Rappresenta il DTO per creare un corso.
    /// </summary>
    public class CreaCorsoDTO
    {
        /// <summary>
        /// Identificativo che fa riferimento al docente che insegna il corso.
        /// </summary>
        public int IDDocente { get; set; }
        /// <summary>
        /// Identificativo che fa riferimento all'aula del corso.
        /// </summary>
        public int IDAula { get; set; }

        /// <summary>
        /// Nome del corso.
        /// </summary>
        public string NomeCorso { get; set; } = null!;

        /// <summary>
        /// Durata del corso.
        /// </summary>
        public string Durata { get; set; } = null!;

        /// <summary>
        /// Data di inizio del corso, nel formato DD/MM/YYYY.
        /// </summary>
        public DateOnly DataInizio { get; set; }
    }
}
