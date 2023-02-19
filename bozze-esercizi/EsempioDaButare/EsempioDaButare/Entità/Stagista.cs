using System.Data.SqlTypes;

namespace EsempioDaButare.Entità
{
    public class Stagista
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Anni { get; set; }
        public decimal SoldiRicevutiInPeriodoStage { get; set; }
        public DateTime InizioStage { get; set; }
        public DateTime FineStage { get; set; }


        //Relazioni tabelle
        public HashSet<Reparto> Reparti { get; set; }=new HashSet<Reparto>();
        
    }
}
