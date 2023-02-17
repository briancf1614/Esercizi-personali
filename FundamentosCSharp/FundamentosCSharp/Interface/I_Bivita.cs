using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSharp.Interface
{
    internal interface I_Bivita
    {
        int Litri { get; set; }
        string Nome { get; set; }
        string Azienda { get; set; }
        string Codigo { get; set; }


        string Bere();
        string Rompersi();
        string Festeggiare();
    }
}
