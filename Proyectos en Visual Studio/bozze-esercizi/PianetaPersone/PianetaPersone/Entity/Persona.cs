using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace PianetaPersone.Entity
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Anni { get; set; }

        //Relazione
        public int PianetaId { get; set; }
        public Pianeta Pianeta { get; set; } = null!;
        public Identificazione Identificazione { get; set; } = null!;

    }
}
