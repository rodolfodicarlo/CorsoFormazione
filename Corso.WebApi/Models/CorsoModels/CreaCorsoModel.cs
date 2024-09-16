using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.CorsoModels
{
    /// <summary>
    /// Modello utilizzato per creare un corso.
    /// </summary>
    public class CreaCorsoModel
    {
        /// <summary>
        /// Identificativo univoco che fa riferimento al docente che insegna nel corso.
        /// </summary>
        public int IDDocente { get; set; }

        /// <summary>
        /// Identificativo univoco che fa riferimento all'aula del corso.
        /// </summary>
        public int IDAula { get; set; }

        /// <summary>
        /// Nome del corso. Deve essere compreso tra 1 e 50 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string NomeCorso { get; set; } = null!;

        /// <summary>
        /// Nome del corso. Deve essere compreso tra 1 e 50 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Durata { get; set; } = null!;

        /// <summary>
        /// Data di inizio del corso. Deve essere nel formato DD/MM/YYYY
        /// </summary>
        [Required]
        public DateOnly DataInizio { get; set; }
    }
}
