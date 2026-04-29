using TiendaProductosDominio.Excepciones;

namespace TiendaProductos.Dominio.ObjetosDeValor
{
    public class CantidadInventario
    {
        public int Valor { get; private set; }
        private CantidadInventario(int valor)
        {
            Valor = valor;
        }

        public static CantidadInventario Crear(int valor)
        {
            if (valor == 0)
            {
                throw new ExcepcioneDeReglaNegocio("El intentario no puede ser negativo.");
            }

            return new CantidadInventario(valor);
        }
    }
}