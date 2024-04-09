using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriaizacionBinaria
{
    [Serializable]
    internal class CAuto
    {
        private double costo;
        private String modelo;

        public CAuto(double PCosto, string PModelo)
        {
            costo = PCosto;
            modelo = PModelo;
        }

        public void MuestraInformacion()
        {
            //Mostramos la información necesaria
            Console.WriteLine("Tu automovil {0}", modelo);
            Console.WriteLine("Costo {0}", costo);
            Console.WriteLine("----------");
        }
    }
}
