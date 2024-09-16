namespace Corso.Service.DTOs.StudenteDTOs
{
    /// <summary>
    /// Rappresenta il DTO per modificare uno studente.
    /// </summary>
    public class ModificaStudenteDTO : CreaStudenteDTO
    {
        /// <summary>
        /// Identificativo univoco dello studente.
        /// </summary>
        public int IDStudente { get; set; }
    }
}
