namespace AziendaPaese.Entita
{
    public class Azienda
    {
        public int Id { get; set; }
        public string NomeDirettore { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Indirizzo { get; set; } = null!;
        public string Citta { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Cap { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public bool Attiva { get; set; }
        public DateTime DataInizioAttivita { get; set; }
    }
}
