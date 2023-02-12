namespace Test1.Entidades
{
    public class PeliculaActor
    {
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;
        public int ActorId { get; set; }
        public Actor Actores { get; set; } = null!;

        public string Personaje { get; set; } = null!;
        public int orden { get; set; }
    }
}
