﻿namespace Corso.Entity.DAL
{
    public class Aula
    {
        public int Idaula { get; set; }

        public string Descrizione { get; set; } = null!;

        public int NumeroPosti { get; set; }
        public ICollection<CorsoEntity> Corso { get; set; } = new HashSet<CorsoEntity>();
    }
}
