namespace Eliminar.Entità
{
    public class Corso
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descrizione { get; set; } = null!;
        public bool Activate { get; set; }
        public DateTime Inizio { get; set; }

        //Relazioni
        public int VotoId { get; set; }
        public Voto Voto { get; set; } = null!;
        public HashSet<Professore> Professori { get; set; } = new HashSet<Professore>();
        public HashSet<Studente> Studenti { get; set; } = new HashSet<Studente>();

    }
}
