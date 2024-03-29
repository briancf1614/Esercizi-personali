using System.ComponentModel.DataAnnotations;

namespace PianetaPersone.Entity
{
    public class Identificazione
    {
        public int Id { get; set; }
        public string Città { get; set; } = null!;
        [DataType("date")]
        public DateTime DataNascita { get; set; }

        //Relazioni

        public int PersonaId { get; set; }
        public Persona Persona { get; set; } = null!;
    }
}
