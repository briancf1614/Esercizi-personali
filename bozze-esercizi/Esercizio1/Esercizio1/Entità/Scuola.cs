namespace Esercizio1.Entità
{
    public class Scuola
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Indirizzo { get; set; } = null!;
        public string Storia { get; set; } = null!;
        public bool Active { get; set; }
        public DateTime DataFondazione { get; set; }


        public HashSet<Professore> Professori { get; set; } = new HashSet<Professore>();
        public HashSet<Studente> Studenti { get; set; } = new HashSet<Studente>();
        //public HashSet<Professore> Professori { get; set; } = new HashSet<Professore>();
    }
}
