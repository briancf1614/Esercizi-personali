using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Dominio.Excepciones;

namespace TiendaProductos.Dominio.ObjetosDeValor
{
    public class Dinero
    {
        public decimal Monto { get; private set; }
        public string Moneda { get; private set; } = default!;

        private Dinero(decimal monto, string moneda)
        {
            Monto = monto;
            Moneda = moneda;
        }

        public static Dinero Crear(decimal monto, string moneda = "USD")
        {
            if (monto < 0)
            {
                throw new ExcepcioneDeReglaNegocio("El monto no puede ser negativo");
            }

            if (string.IsNullOrEmpty(moneda))
            {
                throw new ExcepcioneDeReglaNegocio("La moneda es requerida");
            }

            return new Dinero(monto, moneda);
        }
    }
