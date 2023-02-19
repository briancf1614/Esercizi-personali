namespace AziendaPaese.Entita
{
    public class Progetto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descrizione { get; set; } = null!;
        public bool Attivo { get; set; }
        public DateTime DataInizioAttivita { get; set; }
    }
}
