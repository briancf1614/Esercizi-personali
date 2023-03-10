namespace Proyecto_Roles.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }

        public string Roles { get; set; }

    }
}
