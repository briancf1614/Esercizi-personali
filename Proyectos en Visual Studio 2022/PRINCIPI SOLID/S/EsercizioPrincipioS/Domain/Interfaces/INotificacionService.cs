namespace EsercizioPrincipioS.Domain.Interfaces
{
    public interface INotificacionService
    {
        Task EnviarNotificacion(string destinatario, string mensaje);
    }
}
