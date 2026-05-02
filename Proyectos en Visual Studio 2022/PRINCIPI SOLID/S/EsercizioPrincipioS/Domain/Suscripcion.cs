using EsercizioPrincipioS.Domain.Enums;

namespace EsercizioPrincipioS.Domain
{
    public class Suscripcion
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public TipoPlan PlanActual { get; set; }
        public decimal CostoMensual { get; set; }
        public bool EstaActiva { get; set; }
    }
}
