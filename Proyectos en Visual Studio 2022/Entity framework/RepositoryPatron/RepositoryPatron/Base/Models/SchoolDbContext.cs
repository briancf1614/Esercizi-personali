using Microsoft.EntityFrameworkCore;
using RepositoryPatron.Base.Models.Entita;
using RepositoryPatron.Base.Models.Entita.EntitaSeed;

namespace RepositoryPatron.Base.Models
{
    public class SchoolDbContext: DbContext
    {
        public SchoolDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Professore> Professori { get; set; }
        public DbSet<Scuola> Scuole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ScuolaSeed());
        }
    }
}
