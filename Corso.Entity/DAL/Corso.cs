namespace Corso.Entity.DAL
{
    public class Corso
    {
        public int Idcorso { get; set; }
        public int Iddocente { get; set; }
        public int Idaula{ get; set; }
        public string NomeCorso { get; set; } = null!;
        public string Durata { get; set; } = null!;
        public DateOnly DataInizio { get; set; }
        public virtual Docente Docente { get; set; } = null!;
        public virtual Aula Aula { get; set; } = null!;
    }
}
