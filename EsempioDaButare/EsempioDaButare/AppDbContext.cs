using EsempioDaButare.Entità;
using Microsoft.EntityFrameworkCore;

namespace EsempioDaButare
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        //Possibili modifiche in tabelle override onmodel

        public DbSet<Dipendente> Dipendenti => Set<Dipendente>();
        public DbSet<Fabrica> Fabriche => Set<Fabrica>();
        public DbSet<Paese> Paesi =>Set<Paese>();
        public DbSet<Reparto> Reparti =>Set<Reparto>();
        public DbSet<Stagista>Stagisti => Set<Stagista>();
        public DbSet<Supervisore> Supervisori => Set<Supervisore>();
    }
}
