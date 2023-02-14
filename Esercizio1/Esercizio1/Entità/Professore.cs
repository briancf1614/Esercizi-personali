namespace Esercizio1.Entità
{
    public class Professore
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public string Materia { get; set; } = null!;
        public bool Active { get; set; }
        public DateTime DataInizio { get; set; }

        public HashSet<Corso> Corsi { get; set; } = new HashSet<Corso>();
        public HashSet<Studente> Studenti { get; set; } = new HashSet<Studente>();


    }
}
