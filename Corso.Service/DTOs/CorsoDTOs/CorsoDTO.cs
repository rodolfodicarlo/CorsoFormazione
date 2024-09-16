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
    /// Rappresenta i dati di un corso .
    /// </summary>
    public class CorsoDTO
    {
        /// <summary>
        /// Identificativo univoco del corso
        /// </summary>
        public int IDCorso { get; set; }
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
        /// Oggetto DTO di Aula
        /// </summary>
        public AulaDTO Aula { get; set; } = null!;
        /// <summary>
        /// Oggetto DTO di Docente
        /// </summary>
        public DocenteDTO Docente { get; set; } = null!;
    }
}
