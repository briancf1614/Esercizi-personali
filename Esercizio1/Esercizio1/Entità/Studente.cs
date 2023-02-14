namespace Esercizio1.Entità
{
    public class Studente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public DateTime DataNascita { get; set; }
        public bool Active { get; set; }




        public int ScuolaId { get; set; }
        public Scuola Scuola { get; set; } = null!;


        public HashSet<Professore> Professori { get; set; } = new HashSet<Professore>();
        

        public List<Studente_Corso> Studente_Corsi { get; set; } = new List<Studente_Corso>();
    }
}
