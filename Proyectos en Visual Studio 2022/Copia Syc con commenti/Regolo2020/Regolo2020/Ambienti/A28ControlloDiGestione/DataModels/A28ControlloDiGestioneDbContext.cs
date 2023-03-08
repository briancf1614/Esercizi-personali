using Microsoft.EntityFrameworkCore;
using Regolo2020.Base.DataModels;

namespace Regolo2020.Ambienti.A28ControlloDiGestione.DataModels
{
    public class A28ControlloDiGestioneDbContext : DbContext
    {
        public A28ControlloDiGestioneDbContext(DbContextOptions<A28ControlloDiGestioneDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RegoloDbContext.CreateModelFromTableAssemblyTypes(modelBuilder, GetType().Namespace + ".Tables");
        }
    }
}
