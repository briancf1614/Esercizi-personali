using Eliminar.Entità;
using Microsoft.EntityFrameworkCore;

namespace Eliminar
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }


        public DbSet<AttivitaExtracurricolari> AttivitaExtra => Set<AttivitaExtracurricolari>();
        public DbSet<Corso> Corsi =>Set<Corso>();
        public DbSet<Matricola> Matricole => Set<Matricola>();
        public DbSet<Professore> Professori =>Set<Professore>();
        public DbSet<Scuola> Scuola => Set<Scuola>();
        public DbSet<Studente> Studenti => Set<Studente>();
        public DbSet<Voto> Voti => Set<Voto>();
    }
}
