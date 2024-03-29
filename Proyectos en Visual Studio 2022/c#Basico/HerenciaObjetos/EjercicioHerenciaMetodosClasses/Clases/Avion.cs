using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioHerenciaMetodosClasses.Clases
{
    internal class Avion:Vehiculo
    {
        private bool privado;
        public Avion(bool privado):base("Avion")
        {
            this.privado = privado;
        }
        public override void Conducir()
        {
            Console.WriteLine($"Ahora que crees, estoy conduciendo un {base.nombre} y es {privado.ToString()}");
        }

        public void soyAvionXd()
        {
            Console.WriteLine("Soy un avion perron");
        }
    }
}
