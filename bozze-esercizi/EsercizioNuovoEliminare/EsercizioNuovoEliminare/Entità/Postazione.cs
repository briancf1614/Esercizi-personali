namespace EsercizioNuovoEliminare.Entità
{
    public class Postazione
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        //Relazioni delle tabelle
        public int ClaseId { get; set; }
        public Clase Clase { get; set; } = null!;

        public int StudenteId { get; set; }
        public Studente Studente { get; set; } = null!;

        public int DocenteId { get; set; }
        public Docente Docente { get; set; } = null!;
    }
}
