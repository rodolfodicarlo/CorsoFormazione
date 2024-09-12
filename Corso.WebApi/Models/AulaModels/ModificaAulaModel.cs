using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.AulaModels
{
    /// <summary>
    /// Modello utilizzato per modificare un'aula esistente.
    /// </summary>
    public class ModificaAulaModel : CreaAulaModel
    {
        /// <summary>
        /// Identificativo univoco dell'aula da modificare.
        /// </summary>
        [Required]
        public int IDAula { get; set; }
    }
}
