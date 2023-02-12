namespace Test1.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public DateTime FechaEstreno { get; set; }
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();
        public HashSet<Genero> Generos { get; set; } = new HashSet<Genero>();

        public List<PeliculaActor> PeliculasActores { get; set; } = new List<PeliculaActor>();

    }
}
