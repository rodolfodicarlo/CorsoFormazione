using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.AutenticazioneModels
{
    /// <summary>
    /// Modello utilizzato per registrare un nuovo utente.
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Email dell'utente, deve essere compresa tra 1 e 255 caratteri.
        /// </summary>
        [Required, EmailAddress, MinLength(1), MaxLength(255)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Password dell'utente, deve essere lunga almeno 8 caratteri, deve contenere almeno una lettera maiuscola, un numero e un carattere speciale @$!%*?eCommerciale. 
        /// </summary>
        [Required, RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one digit, and one special character.")]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Cognome dell'utente, deve essere compresa tra 1 e 255 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(255)]
        public string Cognome { get; set; } = null!;

        /// <summary>
        /// Nome dell'utente, deve essere compreso tra 1 e 255 caratteri.
        /// </summary>
        [Required, MinLength(1), MaxLength(255)]
        public string Nome { get; set; } = null!;
    }
}
