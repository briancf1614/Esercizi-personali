using EsercizioPrincipioS.Domain;
using EsercizioPrincipioS.Domain.Enums;
using EsercizioPrincipioS.Domain.Interfaces;

namespace EsercizioPrincipioS.Business.Strategies
{
    public class PenalidadPlanBasico : ICalculadorPenalidadStrategy
    {
        public decimal Calcular(Suscripcion suscripcion)
        {
            return 0m;
        }

        public bool EsAplicable(Suscripcion suscripcion)
        {
            return suscripcion.PlanActual == TipoPlan.Basico;
        }
    }
}
