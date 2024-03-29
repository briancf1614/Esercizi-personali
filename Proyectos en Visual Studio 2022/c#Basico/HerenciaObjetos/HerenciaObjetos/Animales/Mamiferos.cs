using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaObjetos.Animales
{
    internal class Mamiferos
    {
        private string serVivo;
        public Mamiferos(string nombre)
        {
            serVivo = nombre;
        }
        public void Respirar()
        {
            Console.WriteLine("soy un mamifero y respiro");
        }

        public void CuidarCrias()
        {
            Console.WriteLine("soy un mamifero y cuido crias");
            // Se è privated il metodo non puo essere visto in nessuna altra classe, ma se è protected puo essere vista nelle classi figlie
            Respirar();
        }

        public void GetNombre()
        {
            Console.WriteLine($"soy un mamifero y me llamo {serVivo}");
        }

        public virtual void Saltar() //virtual se è una classe base e si può sovrascrivere
        {
            Console.WriteLine("Somos mamiferos y solemos saltar de vez en cuando osea creo.... porque soy un mamifero");
        }

    }
}
