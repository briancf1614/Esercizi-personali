using EComerceB2B.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerceB2B.Business.Strategies
{
    public class DescuentoVipStrategy : IDescuentoStrategy
    {
        private const decimal PorcentajeVip = 0.15m;
        public bool EsAplicable(Pedido pedido) => pedido.Cliente.Tipo == TipoCliente.VIP;
        public decimal Calcular(Pedido pedido) => pedido.Subtotal * PorcentajeVip;
    }
    public class DescuentoMayoristaStrategy : IDescuentoStrategy
    {
        private const decimal UmbralMayorista = 1000m;
        public bool EsAplicable(Pedido pedido) =>
            pedido.Cliente.Tipo == TipoCliente.Mayorista && pedido.Subtotal > UmbralMayorista;
        public decimal Calcular(Pedido pedido) => pedido.Subtotal * 0.10m;
    }

    public class DescuentoPrimeraCompraStrategy : IDescuentoStrategy
    {
        public bool EsAplicable(Pedido pedido) => pedido.EsPrimeraCompra;
        public decimal Calcular(Pedido pedido) => pedido.Subtotal * 0.05m;
    }
}
