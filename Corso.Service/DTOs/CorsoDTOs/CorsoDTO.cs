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
        /// Identificativo univoco del docente responsabile del corso. 
        /// </summary>
        public int IdDocente { get; set; }
        
        /// <summary>
        /// Identificativo univoco dell'aula in cui si svolge il corso.
        /// </summary>
        public int IdAula { get; set; }

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
