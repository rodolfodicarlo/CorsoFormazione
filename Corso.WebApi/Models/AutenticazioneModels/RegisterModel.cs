using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.AutenticazioneModels
{
    public class RegisterModel
    {
        [Required, EmailAddress, MinLength(1), MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(1), MaxLength(255)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one digit, and one special character.")]
        public string Password { get; set; } = string.Empty;
    }
}
