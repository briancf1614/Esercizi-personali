namespace Eliminar.Entità
{
    public class Professore
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public string CodiceFiscale { get; set; } = null!;
        public DateTime DataNascita { get; set; }
        public string LuogoNascita { get; set; } = null!;
        public bool Activate { get; set; }
        
        
        // Relazioni
        public int ScuolaId { get; set; }
        public Scuola Scuola { get; set; } = null!;

        public HashSet<Studente> Studenti { get; set; } = new HashSet<Studente>();
        public HashSet<Corso> Corsi { get; set; } = new HashSet<Corso>();



    }
}
