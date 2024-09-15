using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.CorsoModels
{
    /// <summary>
    /// Modello utilizzato per modificare un corso esistente.
    /// </summary>
    public class ModificaCorsoModel : CreaCorsoModel
    {
        /// <summary>
        /// Identificativo univoco del corso da aggiornare
        /// </summary>
        [Required]
        public int IDStudente { get; set; }
    }
}
