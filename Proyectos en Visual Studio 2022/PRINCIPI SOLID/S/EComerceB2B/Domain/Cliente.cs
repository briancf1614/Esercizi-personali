namespace EComerceB2B.Domain
{
    public enum TipoCliente { Estandar, VIP, Mayorista }
    
    public class Cliente
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nombre { get; set; }
        public TipoCliente Tipo { get; set; }
    }


    public class Pedido
    {
        public Cliente Cliente { get; set; }
        public decimal Subtotal { get; set; }
        public bool EsPrimeraCompra { get; set; }
        public List<string> Etiquetas { get; set; } = new List<string>();
    }

    public interface IDescuentoStrategy
    {
        bool EsAplicable(Pedido pedido);
        decimal Calcular(Pedido pedido);
    }
}
