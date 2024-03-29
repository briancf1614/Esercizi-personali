using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptosPOO
{
    internal class Punto
    {
        private int x, y;
        private static int contadorDeObjetos = 0;
        public Punto(int x, int y)
        {
            this.x = x;
            this.y = y;
            contadorDeObjetos++;
        }

        public Punto()
        {
            this.x = 0;
            this.y = 0;
            contadorDeObjetos++;
        }

        public double distancia(Punto otroPunto)
        {
            int xdif = this.x - otroPunto.x;
            int ydif = this.y - otroPunto.y;

            double distanciaPuntos=Math.Sqrt(Math.Pow(xdif,2)+ Math.Pow(ydif,2));
            return distanciaPuntos;
        }
        public static int ContadorDeObjetos() => contadorDeObjetos;
    }
}
