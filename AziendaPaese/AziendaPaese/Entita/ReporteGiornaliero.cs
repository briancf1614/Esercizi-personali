namespace AziendaPaese.Entita
{
    public class ReporteGiornaliero
    {
        public int Id { get; set; }
        public string Descrizione { get; set; } = null!;
        public DateTime Data { get; set; }
        public int OreLavorate { get; set; }
    }
}
