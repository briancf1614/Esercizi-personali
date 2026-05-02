using EsercizioPrincipioS.Domain;
using EsercizioPrincipioS.Domain.Enums;
using EsercizioPrincipioS.Domain.Interfaces;

namespace EsercizioPrincipioS.Business.Strategies
{
    public class PenalidadPlanPro : ICalculadorPenalidadStrategy
    {
        public decimal Calcular(Suscripcion suscripcion)
        {
            return suscripcion.CostoMensual * 0.20m;
        }

        public bool EsAplicable(Suscripcion suscripcion)
        {
            return suscripcion.PlanActual == TipoPlan.Pro;
        }
    }
}
