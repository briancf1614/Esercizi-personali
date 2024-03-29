using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettersAndSetters
{
    internal partial class Coche
    {
        private int ruedas;
        private double largo;
        private double ancho;
        private bool climatizador;
        private string tapiceria;

        public Coche(int ruedas, double largo, double ancho)
        {
            this.ruedas = ruedas;
            this.largo = largo;
            this.ancho = ancho;
        }

        public string getInfoCoche()
        {
            return $"Informacion del coche: \nruedas={ruedas}\nlargo={largo}\nancho={ancho}";
        }
        //TODO: manca solo la blah blah
        
    }

    internal partial class Coche
    {
        public void setExtras(bool paramClimatizador, string paramTapiceria)
        {
            climatizador=paramClimatizador;
            tapiceria=paramTapiceria;
        }
        public string getExtras()
        {
            return $"Como extras del coche tenemos:\nclimatizador={climatizador}\ntapiceria={tapiceria}";
        }
    }
}
