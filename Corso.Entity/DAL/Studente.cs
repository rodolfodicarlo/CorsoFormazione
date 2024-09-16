using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Entity.DAL
{
    public class Studente
    {
        public int IDStudente { get; set; }
        public string Cognome { get; set; } = null!;

        public string Nome { get; set; } = null!;

        public string Matricola { get; set; } = null!;
    }
}
