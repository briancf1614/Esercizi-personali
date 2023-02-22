namespace EsercizioNuovoEliminare.Entità
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descrizione { get; set; } = null!;
        public int? Ore { get; set; }
        public DateTime? DataInizio { get; set; }
        public bool? InCorso { get; set; }

        //Relazioni delle tabelle

        public int CorsoTotaleId { get; set; }
        public CorsoTotale CorsoTotale { get; set; } = null!;

        public Clase Clase { get; set; } = null!;

        public int DocenteId { get; set; }
        public Docente Docente { get; set; } = null!;

        public HashSet<Studente> Studente { get; set; } = new HashSet<Studente>();

    }
}
