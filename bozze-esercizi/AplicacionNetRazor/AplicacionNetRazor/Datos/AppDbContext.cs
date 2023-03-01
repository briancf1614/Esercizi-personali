using AplicacionNetRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetRazor.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Curso> Curso { get; set; }
                   
    }
}
