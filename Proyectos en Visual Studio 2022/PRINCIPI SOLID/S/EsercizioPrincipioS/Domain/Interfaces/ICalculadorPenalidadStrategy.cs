namespace EsercizioPrincipioS.Domain.Interfaces
{
    public interface ICalculadorPenalidadStrategy
    {
        bool EsAplicable(Suscripcion suscripcion);
        decimal Calcular(Suscripcion suscripcion);
    }
}
