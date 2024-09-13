using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.DocenteDTOs
{
    /// <summary>
    /// Rappresenta il DTO per modificare un docente
    /// </summary>
    public  class ModificaDocenteDTO : CreaDocenteDTO
    {
        /// <summary>
        /// Identificativo univoco del docente
        /// </summary>
        public int IDDocente { get; set; }

    }
}
