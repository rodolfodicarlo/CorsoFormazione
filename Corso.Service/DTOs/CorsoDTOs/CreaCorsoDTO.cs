namespace Corso.Service.DTOs.CorsoDTOs
{
    /// <summary>
    /// Rappresenta il DTO per creare un corso.
    /// </summary>
    public class CreaCorsoDTO
    {
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
        /// Data di inizio del corso, nel formato dd/mm/yyyy.
        /// </summary>
        public DateOnly DataInizio { get; set; }
    }
}
