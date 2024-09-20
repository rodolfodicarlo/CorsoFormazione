namespace Corso.Service.DTOs.AutenticazioneDTOs
{
    /// <summary>
    /// Classe in cui vengono dichiarati i token di accesso e aggiornamento e la loro scadenza.
    /// </summary>
    public class TokenDTO
    {
        /// <summary>
        /// Token di acesso.
        /// </summary>
        public string accessToken { get; set; } = null!;
        
        /// <summary>
        /// Durata in millisecondi dell'accessToken.
        /// </summary>
        public double accessTokenExpire { get; set; }

        /// <summary>
        /// Token di aggiornamento.
        /// </summary>
        public string refreshToken { get; set; } = null!;

        /// <summary>
        /// Durata in millisecondi del refreshToken.
        /// </summary>
        public double refreshTokenExpire { get; set; }
    }
}
