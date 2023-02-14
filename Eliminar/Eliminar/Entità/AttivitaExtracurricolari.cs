namespace Eliminar.Entità
{
    public class AttivitaExtracurricolari
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descrizione { get; set; } = null!;
        public DateTime DataInizio { get; set; }
    }
}
