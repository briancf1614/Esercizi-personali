using HerenciaObjetos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaObjetos.Animales
{
    internal class Caballo : Mamiferos,IAnimalesYDeportes,ISaltoConPatas
    {
        public Caballo(string nombreCaballo) : base(nombreCaballo)
        {

        }
        public void galopar()
        {
            Console.WriteLine("Galopando");
        }

        int ISaltoConPatas.NumeroPatas()
        {
            return 2;
        }

        public override void Saltar()
        {
            Console.WriteLine("Soy un caballo y salto");
        }

        int IAnimalesYDeportes.NumeroPatas()
        {
            return 4;
        }

    }
}
