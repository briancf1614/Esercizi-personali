using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace EsempioDaButare.Entità
{
    public class Fabrica
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public decimal GuadagniAnnuali { get; set; }
        public DateTime DataFondazione { get; set; }
        public bool OperativaAncora { get; set; }

        //Relazioni delle tabelle
        public int PaeseId { get; set; }// Clave foránea para la tabla Paese
        public Paese Paese { get; set; } = null!;// Propiedad de navegación para establecer la relación


        [ForeignKey("Diretore")]
        public int Diretoreid { get; set; }
        public Diretore Diretore { get; set; } = null!;

        public HashSet<Reparto> Reparti { get; set; }=new HashSet<Reparto>();

    }


}
