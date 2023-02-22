namespace EsercizioNuovoEliminare.Entità
{
    public class CorsoTotale
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descrizione { get; set; } = null!;
        public DateTime? Inizio { get; set; }
        public bool? InCorso { get; set; }
        public int? Ore { get; set; }

        //Relazioni delle tabelle
        public int ScuolaId { get; set; }
        public Scuola Scuola { get; set; } = null!;
        public HashSet<Materia> Materie { get; set; } = new HashSet<Materia>();
    }
}
