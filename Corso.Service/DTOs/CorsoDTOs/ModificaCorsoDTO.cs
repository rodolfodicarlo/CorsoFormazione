namespace Corso.Service.DTOs.CorsoDTOs
{
    /// <summary>
    /// Rappresenta il DTO per modificare un corso.
    /// </summary>
    public class ModificaCorsoDTO : CreaCorsoDTO
    {
        /// <summary>
        /// Identificativo univoco del corso. 
        /// </summary>
        public int IdCorso { get; set; }
    }
}
