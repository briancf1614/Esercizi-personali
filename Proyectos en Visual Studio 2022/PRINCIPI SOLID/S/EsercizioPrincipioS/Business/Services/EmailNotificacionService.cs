using EsercizioPrincipioS.Domain.Interfaces;

namespace EsercizioPrincipioS.Business.Services
{
    public class EmailNotificacionService : INotificacionService
    {
        public async Task EnviarNotificacion(string destinatario, string mensaje)
        {
            await Task.Run(() => Console.WriteLine($"Enviando notificación a {destinatario}: {mensaje}"));
        }
    }
}
