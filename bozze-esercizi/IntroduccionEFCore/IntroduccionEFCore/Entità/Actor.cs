namespace IntroduccionEFCore.Entità
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public decimal Fortuna { get; set; }
        public DateTime DataNascita { get; set; }

        //Relazione delle tabelle

        public List<PeliculaActor> PeliculaActors { get; set; } = new List<PeliculaActor>();
    }
}
