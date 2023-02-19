namespace Eliminar.Entità
{
    public class Voto
    {
        public int Id { get; set; }
        public int VotoCurso { get; set; }
        public DateTime DataVoto { get; set; }

        //Relazioni
        public HashSet<Corso> Corsi { get; set; } = new HashSet<Corso>();
    }
}
