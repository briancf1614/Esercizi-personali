using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace EsempioDaButare.Entità
{
    public class Paese
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public bool Live { get; set; }
        public DateTime DataIndependenza { get; set; }
        public decimal soldi { get; set; }

        //Relazioni con le Tabelle
        public HashSet<Fabrica> Fabricas { get; set; } = new HashSet<Fabrica>();



    }
}
