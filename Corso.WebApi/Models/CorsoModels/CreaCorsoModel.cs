using System.ComponentModel.DataAnnotations;
using Corso.Entity.DAL;

namespace Corso.WebApi.Models.CorsoModels
{
    /// <summary>
    /// Modello utilizzato per creare un corso esistente.
    /// </summary>
    public class CreaCorsoModel
    {
        /// <summary>
        /// Nome del corso
        /// </summary>
        [Required,MinLength(1),MaxLength(50)]
        public string NomeCorso { get; set; } = null!;
        /// <summary>
        /// Durata del corso
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Durata { get; set; } = null!;
        /// <summary>
        /// Data Inizio corso
        /// </summary>
        [Required]
        public DateOnly DataInizio { get; set; }
        /// <summary>
        /// Oggetto Aula
        /// </summary>
        public Aula Aula { get; set; } = null!;
        /// <summary>
        /// Oggetto Docente
        /// </summary>
        public Docente Docente { get; set; } = null!;
    }
}
