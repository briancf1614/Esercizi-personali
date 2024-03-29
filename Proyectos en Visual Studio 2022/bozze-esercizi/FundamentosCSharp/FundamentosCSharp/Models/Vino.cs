using FundamentosCSharp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSharp.Models
{
    internal class Vino : I_Bivita
    {
        public int Litri { get; set; }
        public string Nome { get; set; }
        public string Azienda { get; set; }
        public string Codigo { get; set; }


        public string Bere()
        {
            return "Sto Bevendo di brutto sta birra";
        }

        public string Festeggiare()
        {
            return "Stiamo festeggiando con la Birra";
        }

        public string Rompersi()
        {
            return "Ups si è rotta sta birra e che cavolo";
        }

        public string FestaDiVino()
        {
            return "La festa non si fa senza Vino";
        }
    }
}
