namespace Corso.Entity.DAL
{
    public class Docente
    {
        public int Iddocente { get; set; }
        public string Cognome { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public ICollection<Corso> Corso { get; set; } = null!;//virtual
    }
}
