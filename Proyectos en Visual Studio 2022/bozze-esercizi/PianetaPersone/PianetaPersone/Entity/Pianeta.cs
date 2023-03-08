using System.ComponentModel.DataAnnotations;

namespace PianetaPersone.Entity
{
    public class Pianeta
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descrizione { get; set; } = null!;

        //Relazione
        public List<Persona> Persona { get; set; }=new List<Persona>();
    }
}
