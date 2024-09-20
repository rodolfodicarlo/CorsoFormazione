namespace Corso.Service.DTOs.DocenteDTOs
{
    /// <summary>
    /// Rappresenta il DTO per modificare un docente
    /// </summary>
    public class ModificaDocenteDTO
    {
        /// <summary>
        /// Identificativo univoco del docente.
        /// </summary>
        public Guid IDDocente { get; set; }

        /// <summary>
        /// Cognome del docente.
        /// </summary>
        public string Cognome { get; set; } = null!;

        /// <summary>
        /// Nome del docente.
        /// </summary>
        public string Nome { get; set; } = null!;
    }
}
