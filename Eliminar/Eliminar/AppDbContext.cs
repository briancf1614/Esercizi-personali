using Microsoft.EntityFrameworkCore;

namespace Eliminar
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }




    }
}
