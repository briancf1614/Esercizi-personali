using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.classi
{
    internal class Eswitch
    {
        public void eswitch()
        {
            Console.WriteLine("Elige la el tipo de operacion que quieres hacer +-/* ?");
            var tipodeoperacion = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Elige dos numeros para hacer la operacion");
            var a = Convert.ToInt32(Console.ReadLine());
            var b = Convert.ToInt32(Console.ReadLine());

            var result = tipodeoperacion switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => a / b,
                _ => -1
            };
            if (result == -1)
            {
                Console.WriteLine("error papu");
            }
            else
            {
                Console.WriteLine(result);
                Console.ReadLine();
            }
            
        }

        public void eswitchUsandoParenesisEVariabili()
        {
            var (a, b, opcion) = (5, 10, "*");
            var result = opcion switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => a * b,
                _ => -1
            };
            if (result == -1)
            {
                Console.WriteLine("error papu");
            }
            else
            {
                Console.WriteLine(result);
                Console.ReadLine();
            }
            
        }


    }
}
