using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cicli.classi
{
    public class Ciclo
    {
        public void CicloFor()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Ciclo for: " + i);
            }
        }

        public void CicloWhile()
        {
            var data = true;
            var numero = 1;
            while (data)
            {
                Console.WriteLine("este es el ejemplo {0}",numero);
                

                if (numero == 100)
                {
                    data = false;
                }
                numero++;
            }
        }

        public void DoWhile()
        {
            int number = 1;
            do
            {
                Console.WriteLine($"hoy nos toca el numero {number} a webooo!!!");
                number++;
            } while (number <= 100);
        }

        public void ForEach()
        {
            int[] array = new int[100];
            int numero=0;

            foreach (int numerito in array)
            {
                numero++;
                Console.WriteLine($"questa x vale: {numero}");
            }
        }
    }
}
