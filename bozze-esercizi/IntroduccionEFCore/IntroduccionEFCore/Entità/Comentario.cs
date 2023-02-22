namespace IntroduccionEFCore.Entità
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenuto { get; set; } = null!;
        public bool Racomandare { get; set; }

        //Relazione delle tabelle

        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;
    }
}
