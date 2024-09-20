using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.AutenticazioneModels
{
    /// <summary>
    /// Modello utilizzato per effettuare la login di un utente.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Email dell'utente, deve essere compresa tra 1 e 255 caratteri ed essere di questo tipo prova@prova.pr
        /// </summary>
        [Required, EmailAddress, MinLength(1), MaxLength(255)]
        public string Email { get; set; } = null!;
       
        /// <summary>
        /// Password dell'utente.
        /// </summary>
        [Required]
        public string Password { get; set; } = null!;
    }
}
