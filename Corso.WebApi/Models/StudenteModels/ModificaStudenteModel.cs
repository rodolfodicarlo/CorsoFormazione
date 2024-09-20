using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.StudenteModels
{
    /// <summary>
    /// Modello utilizzato per modificare un studente esistente.
    /// </summary>
    public class ModificaStudenteModel
    {
        /// <summary>
        /// Identificativo univoco dello studente da modificare.
        /// </summary>
        [Required]
        public Guid IDStudente { get; set; }

        /// <summary>
        /// Cognome dello studente. Deve essere compreso tra 1 e 50 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Cognome { get; set; } = null!;

        /// <summary>
        /// Nome dello studente. Deve essere compreso tra 1 e 50 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Nome { get; set; } = null!;
    }
}
