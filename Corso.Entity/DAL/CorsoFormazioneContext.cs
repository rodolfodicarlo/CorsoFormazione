using Microsoft.EntityFrameworkCore;

namespace Corso.Entity.DAL
{
    public class CorsoFormazioneContext : DbContext
    {
        public CorsoFormazioneContext() { }

        public CorsoFormazioneContext(DbContextOptions<CorsoFormazioneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aula> Aula { get; set; }
        public virtual DbSet<Docente> Docente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=212.237.41.167;initial catalog=CorsoFormazione-Alessio;user id=sa;password=N2s46Lud7GmJMoqE;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.HasKey(e => e.Idaula);
                entity.Property(e => e.Idaula);
                entity.Property(e => e.Descrizione).IsRequired().HasMaxLength(255);
                entity.Property(e => e.NumeroPosti).IsRequired();
            });
            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.IDDocente);
                entity.Property(e => e.IDDocente);
                entity.Property(e => e.Cognome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<Studente>(entity =>
            {
                entity.HasKey(e => e.IDStudente);
                entity.HasIndex(e => e.Matricola).IsUnique();
                entity.Property(entity => entity.IDStudente);
                entity.Property(e => e.Cognome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Cognome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Matricola).IsRequired().HasMaxLength(50);
            });
        }
        

    }
}
