namespace EsercizioNuovoEliminare.Entità
{
    public class Scuola
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Indirizzo { get; set; }  =null!;
        public string? Citta { get; set; }  =null!;
        public string? Telefono { get; set; }  =null!;
        public string? Email { get; set; }  =null!;
        public string? SitoWeb { get; set; }  =null!;
        public string? Storia { get; set; }  =null!;

        //Relazioni delle tabelle

        public HashSet<Clase> Clasi { get; set; } = new HashSet<Clase>();
        public HashSet<CorsoTotale> Corsi_Totale { get; set; } = new HashSet<CorsoTotale>();


    }
}
