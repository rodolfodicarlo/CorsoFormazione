using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.DocenteModels
{
    /// <summary>
    /// Modello utilizzato per modificare un docente esistente.
    /// </summary>
    public class ModificaDocenteModel
    {

        /// <summary>
        /// Identificativo univoco del docente da modificare.
        /// </summary>
        [Required]
        public Guid IDDocente { get; set; }

        /// <summary>
        /// Cognome del docente. Deve essere compreso tra 1 e 50 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Cognome { get; set; } = null!;

        /// <summary>
        /// Nome del docente. Deve essere compreso tra 1 e 50 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Nome { get; set; } = null!;
    }
}
