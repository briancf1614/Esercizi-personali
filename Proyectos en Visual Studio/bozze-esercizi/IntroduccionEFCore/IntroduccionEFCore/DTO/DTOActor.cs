using AutoMapper;

namespace IntroduccionEFCore.DTO
{
    public class DTOActor
    {
        public string Nome { get; set; } = null!;
        public decimal Fortuna { get; set; }
        public DateTime DataNascita { get; set; }
    }
}
