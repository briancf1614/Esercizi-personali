using System.ComponentModel.DataAnnotations.Schema;

namespace AziendaPaese.Entita
{
    public class Reparto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descrizione { get; set; } = null!;
        public bool Attivo { get; set; }
        public DateTime DataInizioAttivita { get; set; }
        //Relazione Tabelle
        public int AziendaId { get; set; }
        public Azienda Azienda { get; set; } = null!;
        [ForeignKey("SupervisoreReparto")]
        public int SupervisoreRepartoId { get; set; }
        public SupervisoreReparto SupervisoreReparto { get; set; } = null!;
        public HashSet<Dipendente> Dipendenti { get; set; } = new HashSet<Dipendente>();
        public HashSet<Stagista> Stagista { get; set; } = new HashSet<Stagista>();
        
    }
}
