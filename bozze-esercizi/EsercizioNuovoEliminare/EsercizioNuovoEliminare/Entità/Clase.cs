namespace EsercizioNuovoEliminare.Entità
{
    public class Clase
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        //Relazioni delle tabelle
        public int ScuolaId { get; set; }
        public Scuola Scuola { get; set; } = null!;

        public int MateriaId { get; set; }
        public Materia Materia { get; set; } = null!;
        public HashSet<Postazione> Postazioni { get; set; } = new HashSet<Postazione>();

    }
}
