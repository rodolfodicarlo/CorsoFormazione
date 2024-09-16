using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Corso.Entity.DAL
{
    public class CorsoFormazioneContext : IdentityDbContext<IdentityUser>
    {
        public CorsoFormazioneContext() { }

        public CorsoFormazioneContext(DbContextOptions<CorsoFormazioneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aula> Aula { get; set; }
        public virtual DbSet<Corso> Corso { get; set; }
        public virtual DbSet<Docente> Docente { get; set; }
        public virtual DbSet<Studente> Studente { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=212.237.41.167;initial catalog=CorsoFormazione-Luigi;user id=sa;password=N2s46Lud7GmJMoqE;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.HasKey(e => e.Idaula);
                entity.Property(e => e.Idaula);
                entity.Property(e => e.Descrizione).IsRequired().HasMaxLength(255);
                entity.Property(e => e.NumeroPosti).IsRequired();
                //entity.HasMany(e => e.Corso).WithOne(e => e.Aula).
            });

            modelBuilder.Entity<Corso>(entity =>
            {
                entity.HasKey(e => e.Idcorso);
                entity.Property(e => e.Idcorso);
                entity.HasOne(e => e.Aula).WithMany(e => e.Corso).HasForeignKey(e => e.Idaula);
                entity.Property(e => e.Idaula);
                entity.HasOne(e => e.Docente).WithMany(e => e.Corso).HasForeignKey(e => e.Iddocente);
                entity.Property(e => e.Iddocente);
                entity.Property(e => e.NomeCorso).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Durata).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DataInizio).IsRequired();
                
                
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.Iddocente);
                entity.Property(e => e.Iddocente);
                entity.Property(e => e.Cognome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(50);
                //entity.HasMany(e => e.Corso).WithOne(e => e.Docente).
            });

            modelBuilder.Entity<Studente>(entity =>
            {
                entity.HasKey(e => e.Idstudente);
                entity.Property(e => e.Idstudente);
                entity.Property(e => e.Cognome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Matricola).IsUnique();
                entity.Property(e => e.Matricola).IsRequired().HasMaxLength(50);
            });
        }
    }
}
