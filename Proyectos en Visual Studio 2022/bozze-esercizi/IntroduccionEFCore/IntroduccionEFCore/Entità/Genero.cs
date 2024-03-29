namespace IntroduccionEFCore.Entità
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        //Relazione delle tabelle
        public HashSet<Pelicula> Peliculas { get; set; } = new HashSet<Pelicula>();
    }
}
