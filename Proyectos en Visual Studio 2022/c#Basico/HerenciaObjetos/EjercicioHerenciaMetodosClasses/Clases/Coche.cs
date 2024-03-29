using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioHerenciaMetodosClasses.Clases
{
    internal class Coche:Vehiculo
    {
        private string marca;
        public string modelo;
        public Coche(string marca):base("Coche")
        {
            this.marca = marca;
            this.modelo = this.GetType().Name;
        }

        public override void Conducir()
        {
            Console.WriteLine($"Ahora si mi amigo, condusco un Vehiculo de tipo {base.nombre} y de marca {marca} y es de modelo {modelo}");
        }
    }
}
