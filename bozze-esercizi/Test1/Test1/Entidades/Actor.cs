namespace Test1.Entidades
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public bool VivoMuerto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Fortuna { get; set; }

        public List<PeliculaActor> PeliculasActores { get; set; } = new List<PeliculaActor>();
    }
}
