using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductosDominio.Excepciones;
using TiendaProductosDominio.ObjetosDeValor;

namespace TiendaProductosDominio.Entidades
{
    public class Producto
    {
        public Guid Id { get; private set; } = Guid.CreateVersion7();
        public string Nombre { get; private set; } = default!;
        public Dinero Precio { get; private set; } = Dinero.Crear(0);
        public CantidadInventario CantidadInventario { get; private set; } = CantidadInventario.Crear(0);
        public bool Activo { get; private set; } = true;

        public static Producto Crear(string nombre, string? descripcion, Dinero Precio, CantidadInventario inventarioInicial)
        {
            if(string.IsNullOrEmpty(nombre)) {
                throw new ExcepcioneDeReglaNegocio("El nombre del producto es requerido");
        }
    }
}
