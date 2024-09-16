using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.AutenticazioneModels
{
    public class LoginModel
    {
        [Required, EmailAddress, MinLength(1), MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
