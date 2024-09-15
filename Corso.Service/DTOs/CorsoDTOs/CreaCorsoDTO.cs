using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Entity.DAL;

namespace Corso.Service.DTOs.CorsoDTOs
{
    /// <summary>
    /// Rappresenta il DTO per creare un corso
    /// </summary>
    public class CreaCorsoDTO
    {
        /// <summary>
        /// Nome del corso
        /// </summary>
        public string NomeCorso { get; set; } = null!;
        /// <summary>
        /// Durata del corso
        /// </summary>
        public string Durata { get; set; } = null!;
        /// <summary>
        /// Data inizio del corso
        /// </summary>
        public DateOnly DataInizio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Aula Aula { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public Docente Docente { get; set; } = null!;
    }
}
