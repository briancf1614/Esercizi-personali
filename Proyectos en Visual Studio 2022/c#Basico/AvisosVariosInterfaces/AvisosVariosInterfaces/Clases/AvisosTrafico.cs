using AvisosVariosInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisosVariosInterfaces.Clases
{
    internal class AvisosTrafico : IAvisos
    {
        private string remitente;
        private string mensaje;
        private string fecha;

        public AvisosTrafico()
        {
            remitente = "DGT";
            mensaje = "Sancion cometida, Pague antes de 3 dias y se beneficiara en la reduccion de la sancion";
            fecha = "";
        }
        public AvisosTrafico(string remitente, string mensaje, string fecha)
        {
            this.remitente= remitente;
            this.mensaje= mensaje;
            this.fecha= fecha;
        }



        public string GetFecha()
        {
            return fecha;
        }

        public void MostrarAviso()
        {
            Console.WriteLine($"El mensaje {mensaje} ha sido enviado por {remitente} el dia{fecha}");
        }
    }
}
