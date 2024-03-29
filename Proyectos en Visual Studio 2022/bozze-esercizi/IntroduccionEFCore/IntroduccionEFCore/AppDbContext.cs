using IntroduccionEFCore.Entità;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IntroduccionEFCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        // MODIFICA SELEZIONANDO ENTITA PER ENTITA
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actor>().Property(x => x.Nome).HasMaxLength(20);

            //IN QUESTO CASO STO USANDO REFLECTIONS PER TROVARE LE CLASSI CHE IMPLEMENTANO IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /*
        // MODIFICA COMPLETAMENTE LE CONVENZIONI DI DEFAULT

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
        */


        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PeliculaActor> PeliculaActors { get; set; }


    }
}
