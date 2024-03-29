using System.ComponentModel.DataAnnotations;

namespace AplicacionNetRazor.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre de Curso")]
        
        public string NombreCurso { get; set; }
        [Display(Name = "Cantidad de clases")]
        public int CantidadClases { get; set; }
        public int Precio { get; set; }
        [Display(Name = "Fecha de Creacion")]
        public DateTime FechaCreacion { get; set; }

    }
}
