using FundamentosCSharp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSharp.Models
{
    internal class Birra : Gassosa, I_Bivita
    {
        

        public string BirraPerTutti()
        {
            return "Sto regalando birre per tutti";
        }

    }
}
