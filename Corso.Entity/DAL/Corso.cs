using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Entity.DAL
{
    public class Corso
    {
        public int IDCorso { get; set; }
        public int IDDocente { get; set; }
        public virtual Docente Docente { get; set; } = null!;
        public int IDAula { get; set; }
        public virtual Aula Aula { get; set; } = null!;
        public string NomeCorso { get; set; } = null!;
        public string Durata { get; set; } = null!;
        public DateOnly DataInizio { get; set; }

         
    }
}
