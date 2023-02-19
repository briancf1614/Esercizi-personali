using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Test1.Entidades;

namespace Test1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //modifica per ogni entita
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            //aggiungo la cartella Configurations usando sti metodi che cercheranno tutte le classi che implementano linterfaccia IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            //    //Con questi codici modifico il comportamento di ogni entità usando api fluenti

            //    //Actor
            //    modelBuilder.Entity<Actor>().HasKey(e => e.Id);
            //    modelBuilder.Entity<Actor>().Property(e => e.Nombre).HasMaxLength(10);
            //    modelBuilder.Entity<Actor>().Property(e => e.Apellido).HasMaxLength(10);
            //    modelBuilder.Entity<Actor>().Property(e => e.FechaNacimiento).HasColumnType("date");
            //    //Comentario
            //    modelBuilder.Entity<Comentario>().HasKey(c => c.Id);
            //    modelBuilder.Entity<Comentario>().Property(c => c.Contenido).HasMaxLength(500);
            //    //Genero
            //    modelBuilder.Entity<Genero>().HasKey(g => g.Id);
            //    modelBuilder.Entity<Genero>().Property(g => g.Nombre).HasMaxLength(10);
            //    //Pelicula
            //    modelBuilder.Entity<Pelicula>().HasKey(p => p.Id);
            //    modelBuilder.Entity<Pelicula>().Property(p => p.Titulo).HasMaxLength(10);
            //    modelBuilder.Entity<Pelicula>().Property(p => p.FechaEstreno).HasColumnType("date");
        }


        ////Nel caso potresti anche modificare le convenzioni(sono le istruzioni predefinite nel caso non usassi api fluenti)
        
        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    configurationBuilder.Properties<string>().HaveMaxLength(150);
        //}

        public DbSet<Actor> Actores => Set<Actor>();   
        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();
        public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();
    }
}
