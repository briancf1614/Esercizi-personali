using EFBase.Models.Entity;
using EfTestBase.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfTestBase.Models
{
    public class CursoDbContext:DbContext
    {
        public CursoDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<WorkingExperience> Wokringgexperience { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(); //serve per fare tutti quelli che ereditano di Ientityframeworkin automatico
            modelBuilder.ApplyConfiguration(new UserSeed());

        }
    }
}
