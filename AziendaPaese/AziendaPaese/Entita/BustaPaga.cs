namespace AziendaPaese.Entita
{
    public class BustaPaga
    {
        public int Id { get; set; }
        public string Banca { get; set; } = null!;
        public bool Pagata { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
