namespace Eliminar.Entità
{
    public class Studente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public string CodiceFiscale { get; set; } = null!;
        public DateTime DataNascita { get; set; }
        public string LuogoNascita { get; set; } = null!;
        public bool Studia { get; set; }

        //Relazioni

        public int ScuolaId { get; set; }
        public Scuola Scuola { get; set; } = null!;
        public int MatricolaId { get; set; }
        public Matricola Matricola { get; set; } = null!;

        public HashSet<Professore> Professores { get; set; } = new HashSet<Professore>();
        public HashSet<Corso> Corsi { get; set; } = new HashSet<Corso>();
        public HashSet<AttivitaExtracurricolari> AttivitaExtra { get; set; } = new HashSet<AttivitaExtracurricolari>();



    }
}
