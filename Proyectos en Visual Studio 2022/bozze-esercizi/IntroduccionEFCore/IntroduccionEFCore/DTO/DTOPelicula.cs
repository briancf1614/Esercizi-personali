namespace IntroduccionEFCore.DTO
{
    public class DTOPelicula
    {
        public string Nome { get; set; } = null!;
        public bool Encines { get; set; }
        public DateTime DataUscita { get; set; }


        //qua dico che sia di tipo int perche mi serve solo l'id di genero
        public List<int> Generos { get; set; }=new List<int>();
        // in questo caso 
        public List<PeliculaActorDTO> PeliculaActores { get; set; }=new List<PeliculaActorDTO>();

 
    }
}
