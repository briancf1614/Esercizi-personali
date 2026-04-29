using EComerceB2B.Domain;

namespace EComerceB2B.Business
{
    public interface IMotorPrecios { decimal ObtenerTotalFinal(Pedido pedido); }
    public class MotorDePrecios : IMotorPrecios
    {
        private readonly IEnumerable<IDescuentoStrategy> _estrategias;

        public MotorDePrecios(IEnumerable<IDescuentoStrategy> estrategias)
        {
            _estrategias = estrategias;
        }

        public decimal ObtenerTotalFinal(Pedido pedido)
        {
            var descuentosAplicables = _estrategias
                .Where(s => s.EsAplicable(pedido))
                .Select(s => s.Calcular(pedido))
                .ToList();

            decimal mejorDescuento = descuentosAplicables.Any() ? descuentosAplicables.Max() : 0;
            return pedido.Subtotal - mejorDescuento;
        }
    }
}
