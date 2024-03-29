using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaObjetos.Animales
{
    internal class Humano : Mamiferos
    {
        public Humano(string nombrePersona) : base(nombrePersona)
        {

        }
        public void Pensar()
        {
            Console.WriteLine("Pensando");
            Respirar();
        }
        public override void Saltar()
        {
            Console.WriteLine("Soy un humano y solo en campeonatos Xd");
        }
    }
}
