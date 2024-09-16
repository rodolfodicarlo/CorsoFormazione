using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.DocenteModels
{
    /// <summary>
    /// Rappresenta il modello dell'oggeeto docente
    /// </summary>
    public class DocenteModel
    {
        /// <summary>
        /// Identificativo univoco del docente da modifcare .
        /// </summary>
        [Required]
        public int IDDocente { get; set; }
        /// <summary>
        /// Il cognome del docente . Deve essere compreso fra 1 e 50 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Cognome { get; set; } = null!;
        /// <summary>
        /// Nome del docente . Deve essere compreso fra 1 e 50 caratteri. 
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Nome { get; set; } = null!;
    }
}
