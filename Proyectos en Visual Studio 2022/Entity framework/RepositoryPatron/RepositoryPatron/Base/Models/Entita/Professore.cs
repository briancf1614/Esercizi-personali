namespace RepositoryPatron.Base.Models.Entita
{
    public class Professore:BaseAllEntita
    {
        public string Cognome { get; set; }
        public string AnniDiEsperienza { get; set; }
        public string Provenienza { get; set; }
        public IEnumerable<Corso> Corsi { get; set; }
        public Scuola Scuola { get; set; }
    }
}