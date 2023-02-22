namespace EsercizioNuovoEliminare.Entità
{
    public class Studente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public int Anni { get; set; }
        public string? Indirizzo { get; set; }  =null!;
        public string? Citta { get; set; }  =null!;
        public DateTime? DataDiNascita { get; set; }
        public string? Nazionalita { get; set; }  =null!;
        
        //Relazioni delle tabelle
        public Postazione Postazione { get; set; } = null!;
        public int CorsoTotaleId { get; set; }
        public CorsoTotale CorsoTotale { get; set; } = null!;
        public HashSet<Materia> Materie { get; set; } = new HashSet<Materia>();




    }
}
