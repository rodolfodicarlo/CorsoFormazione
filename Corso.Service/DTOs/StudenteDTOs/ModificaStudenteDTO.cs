namespace Corso.Service.DTOs.StudenteDTOs
{
    /// <summary>
    /// Rappresenta il DTO per modificare uno studente.
    /// </summary>
    public class ModificaStudenteDTO
    {
        /// <summary>
        /// Identificativo univoco dello studente.
        /// </summary>
        public Guid IDStudente { get; set; }

        /// <summary>
        /// Cognome dello studente.
        /// </summary>
        public string Cognome { get; set; } = null!;

        /// <summary>
        /// Nome dello studente.
        /// </summary>
        public string Nome { get; set; } = null!;

        ///// <summary>
        ///// Matricola univoca dello studente.
        ///// </summary>
        //public string Matricola { get; set; } = null!;
    }
}
