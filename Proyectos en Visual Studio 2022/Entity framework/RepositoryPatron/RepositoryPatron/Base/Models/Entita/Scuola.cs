namespace RepositoryPatron.Base.Models.Entita
{
    public class Scuola:BaseAllEntita
    {
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public IEnumerable<Corso> Corsi { get; set; }
        public IEnumerable<Studente> Studenti { get; set; }
        public IEnumerable<Professore> Professori { get; set; }
    }
}