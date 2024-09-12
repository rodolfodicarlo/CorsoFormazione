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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=212.237.41.167;initial catalog=CorsoFormazione-Matteo;user id=sa;password=N2s46Lud7GmJMoqE;TrustServerCertificate=True;");

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
        }
    }
}
