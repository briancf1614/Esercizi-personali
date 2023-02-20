namespace AziendaPaese.Entita
{
    public class BustaPaga
    {
        public int Id { get; set; }
        public string Banca { get; set; } = null!;
        public bool Pagata { get; set; }
        public DateTime DataPagamento { get; set; }

        //Relazione Tabelle

        public int DipendenteId { get; set; }
        public Dipendente Dipendente { get; set; } = null!;
        public int StagistaId { get; set; }
        public Stagista Stagista { get; set; } = null!;
        public int SupervisoreRepartoId { get; set; }
        public SupervisoreReparto SupervisoreReparto { get; set; } = null!;

    }
}
