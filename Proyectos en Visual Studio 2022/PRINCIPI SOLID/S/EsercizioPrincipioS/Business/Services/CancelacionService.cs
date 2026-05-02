using EsercizioPrincipioS.Domain;
using EsercizioPrincipioS.Domain.Interfaces;

namespace EsercizioPrincipioS.Business.Services
{
    public class CancelacionService : ICancelacionService
    {
        private readonly IEnumerable<ICalculadorPenalidadStrategy> _strategiesPenalidad;
        private readonly INotificacionService _notificacionService;
        public CancelacionService(IEnumerable<ICalculadorPenalidadStrategy> strategiesPenalidad, INotificacionService notificacionService)
        {
            _strategiesPenalidad = strategiesPenalidad;
            _notificacionService = notificacionService;
        }

        public async Task<ResultadoCancelacion> CancelarSuscripcion(Suscripcion suscripcion)
        {
            var strategy = _strategiesPenalidad.FirstOrDefault(s => s.EsAplicable(suscripcion));
            if (strategy == null) throw new InvalidOperationException($"No existe estrategia de cancelación para el plan {suscripcion.PlanActual}");
            
            var penalidad = strategy.Calcular(suscripcion);
            suscripcion.EstaActiva = false;

            await _notificacionService.EnviarNotificacion(
                suscripcion.Usuario.Email,
                $"Tu suscripción ha sido cancelada. Penalidad aplicada: {penalidad}");

            return new ResultadoCancelacion
            {
                Exito = true,
                PenalidadCobrada = penalidad,
                Mensaje = "Suscripcion cancelada correctamente"
            };
        }
    }
}
