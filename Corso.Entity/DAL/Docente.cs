using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Entity.DAL
{
    public class Docente
    {
        public int IDDocente { get; set; }
        public string Cognome { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public ICollection<CorsoEntity> Corso { get; set; }= null!;

    }
}
