namespace AziendaPaese.Entita
{
    public class Dipendente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public string CodiceFiscale { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public string Iban { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Attivo { get; set; }
        public DateTime DataInizioAttivita { get; set; }
    }
}
