namespace Eliminar.Entità
{
    public class Scuola
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Indirizzo { get; set; } = null!;
        public string Citta { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string SitoWeb { get; set; } = null!;
        public DateTime DataFondazione { get; set; }
        public bool IsCattolica { get; set; }


    }
}
