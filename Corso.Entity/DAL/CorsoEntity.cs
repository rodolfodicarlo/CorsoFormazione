using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Entity.DAL
{
    public class CorsoEntity
    {
        public int IDCorso { get; set; }
        public int IDDocente { get; set; }
        public int IDAula { get; set; }
        public string NomeCorso { get; set; } = null!;
        public string Durata { get; set; } = null!;
        public DateOnly DataInizio { get; set; } 
        public virtual Aula Aula { get; set; } = null!;
        public virtual Docente Docente { get; set; } = null!;

    }
}
