namespace Corso.Service.DTOs.DocenteDTOs
{
    /// <summary>
    /// Rappresenta i dati di un docente.
    /// </summary>
    public class DocenteDTO
    {
        /// <summary>
        /// Identificativo univoco del docente.
        /// </summary>
        public int IDDocente { get; set; }

        /// <summary>
        /// Cognome del docente.
        /// </summary>
        public string Cognome { get; set; } = null!;
        
        /// <summary>
        /// Nome dello studente.
        /// </summary>
        public string Nome { get; set; } = null!;
    }
}
