using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class BarContext:DbContext
    {
        public BarContext(DbContextOptions<BarContext> options) : base(options)
        {
            
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
