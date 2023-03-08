namespace IntroduccionEFCore.Entità
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public DateTime DataUscita { get; set; }
        public bool Encines { get; set; }

        //Relazione delle tabelle
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();
        public HashSet<Genero> Generos { get; set; } = new HashSet<Genero>();

        public List<PeliculaActor> PeliculaActors { get; set; } = new List<PeliculaActor>();

    }
}
