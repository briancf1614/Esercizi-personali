namespace RepositoryPatron.Base.Models.Entita
{
    public class Corso : BaseAllEntita
    {
        public int DurataGiorni { get; set; }
        public string Descrizione { get; set; }
        public Professore Professore { get; set; }
        public IEnumerable<Studente> Studenti { get; set; }
        public Scuola Scuola { get; set; }
    }
}