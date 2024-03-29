using ejercicioClasseGenerica_borrar_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioClasseGenerica_borrar_
{
    internal class AlmacenDePersonas<T>where T:ITrabajador
    {
        private int i = 0;
        private T[] datosEmpleado;

        public AlmacenDePersonas(int z)
        {
            datosEmpleado = new T[z];
        }

        public void agregar(T obj)
        {
            datosEmpleado[i] = obj;
            i++;
        }

        public T getEmpleado(int i)
        {
            return datosEmpleado[i];
        }

    }
}
