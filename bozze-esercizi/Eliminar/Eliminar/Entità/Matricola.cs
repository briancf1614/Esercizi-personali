namespace Eliminar.Entità
{
    public class Matricola
    {
        public int Id { get; set; }
        public float Pagamento { get; set; }
        public DateTime DataPagamento { get; set; }

        //Relazioni
        public HashSet<Studente> Studenti { get; set; } = new HashSet<Studente>();
    }
}
