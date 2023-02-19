namespace EsempioDaButare.Entità
{
    public class Supervisore
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public int AnniEsperienza { get; set; }
        public bool LavoraAncora { get; set; }
    }
}
