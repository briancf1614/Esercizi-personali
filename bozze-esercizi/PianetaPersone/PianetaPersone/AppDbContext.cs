using Microsoft.EntityFrameworkCore;
using PianetaPersone.Entity;

namespace PianetaPersone
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Persona> Persone { get; set; }
        public DbSet<Pianeta> Pianeti { get; set; }
        public DbSet<Identificazione> Identificazioni { get; set; }

    }
}
