namespace Test1.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; } = null!;
        public bool Recomendar { get; set; }
        public int PeliculaId { get; set; }//questo serve solo per dire di prendere la primary key di Paese(credo usi le convenzioni quindi riesce a riconoscere solo inserendo il NomeClasseId
        
        public Pelicula Pelicula { get; set; } = null!;//questo serve per creare la proprieta nella classe ovvero tabella
        
        
        
    }
}
