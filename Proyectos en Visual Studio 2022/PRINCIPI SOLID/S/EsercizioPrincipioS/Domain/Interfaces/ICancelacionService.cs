using EsercizioPrincipioS.Domain;

namespace EsercizioPrincipioS.Domain.Interfaces
{
    public interface ICancelacionService
    {
        Task<ResultadoCancelacion> CancelarSuscripcion(Suscripcion suscripcion);
    }
}
