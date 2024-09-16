using Corso.Service.DTOs.AulaDTOs;
using Corso.Service.DTOs.DocenteDTOs;

namespace Corso.Service.DTOs.CorsoDTOs
{
    /// <summary>
    /// Rappresenta i dati di un corso.
    /// </summary>
    public class CorsoDTO
    {
        /// <summary>
        /// Identificativo univoco del corso.
        /// </summary>
        public int IdCorso { get; set; }

        /// <summary>
        /// Docente responsabile del corso. 
        /// </summary>
        public DocenteDTO Docente { get; set; } = null!;

        /// <summary>
        /// Aula in cui si svolge il corso.
        /// </summary>
        public AulaDTO Aula { get; set; } = null!;

        /// <summary>
        /// Nome del corso.
        /// </summary>
        public string NomeCorso { get; set; } = null!;

        /// <summary>
        /// Durata del corso.
        /// </summary>
        public string Durata { get; set; } = null!;

        /// <summary>
        /// Data di inizio del corso, nel formato yyyy/mm/dd.
        /// </summary>
        public DateOnly DataInizio { get; set; }
    }
}
