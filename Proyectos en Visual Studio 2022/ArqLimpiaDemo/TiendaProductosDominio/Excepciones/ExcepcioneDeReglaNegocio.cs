using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaProductos.Dominio.Excepciones
{
    public class ExcepcioneDeReglaNegocio : Exception
    {
        public ExcepcioneDeReglaNegocio(string mensaje): base(mensaje)
        {
            
        }
    }
}
