using ejercicioClasseGenerica_borrar_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioClasseGenerica_borrar_.Escuela
{
    internal class Profesor : IEscuela
    {
        private string escuela;
        public Profesor(string escuela)
        {
            this.escuela = escuela;
        }
        public string GetEscuela()
        {
            return escuela;
        }
    }
}
