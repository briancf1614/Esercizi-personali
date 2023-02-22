namespace EsercizioNuovoEliminare.Entità
{
    public class Docente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public int? OreDilavoro { get; set; }
        public string? Indirizzo { get; set; } = null!;
        public string? Citta { get; set; } = null!;
        public DateTime? DataDiNascita { get; set; }
        public string? Nazionalita { get; set; } = null!;
        public bool? InCorso { get; set; }

        //Relazione delle tabelle

        public Postazione Postazione { get; set; } = null!;

        public Materia Materia { get; set; } = null!;

    }
}
