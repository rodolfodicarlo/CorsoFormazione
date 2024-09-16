using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.CorsoModels
{
    /// <summary>
    /// Modello utilizzato per creare un corso
    /// </summary>
    public class CreaCorsoModel
    {
        /// <summary>
        /// Identificativo univoco del docente responsabile del corso.
        /// </summary>
        [Required]
        public int IdDocente { get; set; }

        /// <summary>
        /// Identificativo univoco del aula in cui si svolge il corso.
        /// </summary>
        [Required]
        public int IdAula { get; set; }

        /// <summary>
        /// Nome del corso. Deve essere compreso tra 1 e 50 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string NomeCorso { get; set; } = null!;

        /// <summary>
        /// Durata del corso. Deve essere compresa tra 1 e 50 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Durata { get; set; } = null!;

        /// <summary>
        /// Data di inizio del corso. Deve essere nel formato dd/mm/yyyy.
        /// </summary>
        [Required]
        public DateOnly DataInizio { get; set; }

    }
}
