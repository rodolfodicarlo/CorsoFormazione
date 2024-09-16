using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.StudenteModels
{
    /// <summary>
    /// Modello utilizzato per modificare uno studente esistente.
    /// </summary>
    public class ModificaStudenteModel : CreaStudenteModel
    {
        /// <summary>
        /// Identificativo univoco dello studente da modificare
        /// </summary>
        [Required]
        public int IDStudente { get; set; }
    }
}
