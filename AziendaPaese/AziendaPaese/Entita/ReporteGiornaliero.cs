namespace AziendaPaese.Entita
{
    public class ReporteGiornaliero
    {
        public int Id { get; set; }
        public string Descrizione { get; set; } = null!;
        public DateTime Data { get; set; }
        public int OreLavorate { get; set; }
        //Relazione Tabelle

        public int DipendenteId { get; set; }
        public Dipendente Dipenndente { get; set; } = null!;

        public int StagistaId { get; set; }
        public Stagista Stagista { get; set;} = null!;

        public int SupervisoreRepartoId { get; set; }
        public SupervisoreReparto SupervisoreReparto { get; set; } = null!;

    }
}
