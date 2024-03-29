using ejercicioClasseGenerica_borrar_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioClasseGenerica_borrar_.Trabajadores
{
    internal class Electricista : ITrabajador
    {
        private double salario;
        public Electricista(double salario)
        {
            this.salario = salario;
        }

        public double GetSalario()
        {
            return salario;
        }
    }
}
