using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.AulaModels
{
    /// <summary>
    /// Modello utilizzato per creare un'aula.
    /// </summary>
    public class CreaAulaModel
    {
        /// <summary>
        /// Nome o descrizione dell'aula. Deve essere compresa tra 1 e 100 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(255)]
        public string Descrizione { get; set; } = null!;

        /// <summary>
        /// Numero totale di posti disponibili nell'aula.
        /// </summary>
        [Required]
        public int NumeroPosti { get; set; } 
    }
}