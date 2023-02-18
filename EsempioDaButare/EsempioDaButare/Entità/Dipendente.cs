using System.Data.SqlTypes;

namespace EsempioDaButare.Entità
{
    public class Dipendente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public decimal GuadagniAnnuali { get; set; }
        public int Anni { get; set; }
        public int AnniEsperienza { get; set; }
        public bool LavoraAncora { get; set; }
        public DateTime DataAsunzione { get; set; }

        //Relazioni tabelle
        public HashSet<Reparto> Reparti { get; set; }=new HashSet<Reparto>();

    }
}
