using System.ComponentModel.DataAnnotations.Schema;

namespace EsempioDaButare.Entità
{
    public class Diretore
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public bool Active { get; set; }
        public int Anni { get; set; }
        public DateTime DataInizio { get; set; }

        //Relazioni Tabelle

        [ForeignKey("Fabrica")]
        public int FabricaId { get; set; }
        public Fabrica Fabrica { get; set; } = null!;

    }
}
