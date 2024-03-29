namespace RepositoryPatron.Base.Models.Entita
{
    public class Studente:BaseAllEntita
    {
        public string Cognome { get; set; }
        public string DataDiNascita { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public IEnumerable<Professore> Professori { get; set;}
        public IEnumerable<Corso> Corsi { get; set; }
        public Scuola Scuola { get; set; }
    }
}