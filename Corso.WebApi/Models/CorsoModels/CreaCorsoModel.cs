using System.ComponentModel.DataAnnotations;
using Corso.Entity.DAL;
using Corso.WebApi.Models.AulaModels;
using Corso.WebApi.Models.DocenteModels;

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
        /// Identificativo Aula
        /// </summary>
        public int IDDocente { get; set; }
        /// <summary>
        /// Identificativo Docente
        /// </summary>
        public int IDAula { get; set; }
    }
}
