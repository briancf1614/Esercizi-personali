using Esercizio1.Entità;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Esercizio1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Scuola>().Property(s=>s.Storia).HasMaxLength(500);
            }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(100);
        }


        public DbSet<Scuola> Scuole => Set<Scuola>();
        public DbSet<Professore> Professori => Set<Professore>();
        public DbSet<Studente> Studenti => Set<Studente>();
        public DbSet<Corso> Corsi => Set<Corso>();
        public DbSet<Studente_Corso> Studente_Corso => Set<Studente_Corso>();

    }
}
