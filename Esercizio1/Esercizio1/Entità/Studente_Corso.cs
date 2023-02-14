using System.ComponentModel.DataAnnotations;

namespace Esercizio1.Entità
{
    public class Studente_Corso
    {
        public int StudenteId { get; set; }
        public Studente Studente { get; set; } = null!;
        public int CorsoId { get; set; }
        public Corso Corso { get; set; }  =null!;

    }
}
