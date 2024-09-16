using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Entity.DAL;
using Corso.Service.DTOs.AulaDTOs;
using Corso.Service.DTOs.DocenteDTOs;

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
        /// Oggetto dto Aula
        /// </summary>
        public AulaDTO Aula { get; set; } = null!;
        /// <summary>
        /// Oggetto DTO Docente
        /// </summary>
        public DocenteDTO Docente { get; set; } = null!;
    }
}
