namespace Esercizio1.Entità
{
    public class Corso
    {
        public int Id { get; set; }
        public string NomeCorso { get; set; } = null!;
        public string Descrizione { get; set; } = null!;
        public bool Active { get; set; }
        public DateTime DataInizio { get; set; }

        public int ProfessoreId { get; set; }
        public Professore Professore { get; set; } = null!;
        
        
        public List<Studente_Corso> Studente_Corsi { get; set; } = new List<Studente_Corso>();
    }
}
