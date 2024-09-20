namespace Corso.Entity.DAL
{
    public class Studente
    {
        //public int Idstudente { get; set; }
        public Guid Idstudente { get; set; }
        public string Cognome { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Matricola { get; set; } = null!;
    }
}
