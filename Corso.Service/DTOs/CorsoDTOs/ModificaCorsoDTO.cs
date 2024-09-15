using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.CorsoDTOs
{
    /// <summary>
    /// Rappresenta il DTO per aggiornare un corso
    /// </summary>
    public class ModificaCorsoDTO : CreaCorsoDTO
    {
        /// <summary>
        /// Identificativo univoco del corso
        /// </summary>
        public int IDCorso { get; set; }
    }
}
