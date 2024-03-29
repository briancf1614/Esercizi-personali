using FundamentosCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Birra Test1 = new Birra();
            Console.WriteLine(Test1.NonSoloPerBambini());
            Console.Read();
            
        }
    }
}
