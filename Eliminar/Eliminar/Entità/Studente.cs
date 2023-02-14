namespace Eliminar.Entità
{
    public class Studente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public string CodiceFiscale { get; set; } = null!;
        public DateTime DataNascita { get; set; }
        public string LuogoNascita { get; set; } = null!;
        public bool Studia { get; set; }

    }
}
