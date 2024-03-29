using Microsoft.EntityFrameworkCore;

namespace PokemonReview
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
