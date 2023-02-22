using EsercizioNuovoEliminare.Entità;
using Microsoft.EntityFrameworkCore;

namespace EsercizioNuovoEliminare
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Materia>().Property(m=>m.InCorso).HasMaxLength(100);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }


        public DbSet<Clase> Clasi { get; set; }
        public DbSet<CorsoTotale> Corsi_Totali { get;set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<Materia> Materie { get; set; }
        public DbSet<Postazione> Postazioni { get; set; }
        public DbSet<Scuola> Scuole { get; set; }
        public DbSet<Studente> Studenti { get; set; }
    }
}
