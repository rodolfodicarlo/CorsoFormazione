using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.Studente_DTOs
{
    /// <summary>
    /// Rappresenta il DTO per modificare lo studente 
    /// </summary>
    public class ModificaStudenteDTO : CreaStudenteDTO
    {
        /// <summary>
        /// Identificativo univoco dello studente
        /// </summary>
        public int IDStudente { get; set; }
    }
}
