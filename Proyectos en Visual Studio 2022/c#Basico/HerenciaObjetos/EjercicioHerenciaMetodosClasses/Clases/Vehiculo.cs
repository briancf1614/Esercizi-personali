using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioHerenciaMetodosClasses.Clases
{
    internal class Vehiculo
    {
        protected string nombre;
        public Vehiculo(string nombre)
        {
            this.nombre = nombre;
            Console.WriteLine($"gracias por crearme soy el vehivulo {nombre}");
        }

        public void Arrancar()
        {
            Console.WriteLine("Arrancando Vehiculo");
        }

        public void PararMotor()
        {
            Console.WriteLine("Parando Vehiculo");
        }

        public virtual void Conducir()
        {
            Console.WriteLine("Conduciendo nose que Vehiculo");
        }

        public void soyVehiculoXd()
        {
            Console.WriteLine("Soy un vehiculo perron");
        }
    }
}
