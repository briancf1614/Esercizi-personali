namespace AziendaPaese.Entita
{
    public class Stagista
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
        //Relazione Tabelle
        public int RepartoId { get; set; }
        public Reparto Reparto { get; set; } = null!;
        public HashSet<ReporteGiornaliero> ReportiGiornalieri { get; set; } = new HashSet<ReporteGiornaliero>();
        public HashSet<Progetto> Progetti { get; set; }=new HashSet<Progetto>();
        public HashSet<BustaPaga> BustePaghe { get; set;}=new HashSet<BustaPaga>();


    }
}
