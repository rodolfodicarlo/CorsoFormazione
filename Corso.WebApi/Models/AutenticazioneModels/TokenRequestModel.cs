using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.AutenticazioneModels
{
    /// <summary>
    /// Modello utilizzato per richiedere un token di accesso.
    /// </summary>
    public class TokenRequestModel
    {
        /// <summary>
        /// Username delle ServerCredential.
        /// </summary>
        [Required]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Password delle ServerCredential.
        /// </summary>
        [Required]
        public string Password { get; set; } = null!;
    }
}
