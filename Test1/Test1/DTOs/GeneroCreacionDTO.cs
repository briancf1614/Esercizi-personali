using System.ComponentModel.DataAnnotations;

namespace Test1.DTOs
{
    public class GeneroCreacionDTO
    {
        [StringLength(maximumLength: 20)]
        public string Nombre { get; set; } = null!;
    }
}
