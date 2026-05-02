using EsercizioPrincipioS.Domain;
using EsercizioPrincipioS.Domain.Enums;
using EsercizioPrincipioS.Domain.Interfaces;

namespace EsercizioPrincipioS.Business.Strategies
{
    public class PenalidadPlanEnterprise : ICalculadorPenalidadStrategy
    {
        public decimal Calcular(Suscripcion suscripcion)
        {
            return 150m;
        }

        public bool EsAplicable(Suscripcion suscripcion)
        {
            return suscripcion.PlanActual == TipoPlan.Enterprise;
        }
    }
}
