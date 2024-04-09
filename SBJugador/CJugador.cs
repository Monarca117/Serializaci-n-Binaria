using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBJugador
{
    [Serializable]
    internal class CJugador
    {
        private String name;
        private String role;
        private int level;

        public CJugador(String pName, string pRole, int pLevel)
        {
            name = pName;
            role = pRole;
            level = pLevel;
        }

        public void MuestraInformacion()
        {
            //Mostramos la información necesaria
            Console.WriteLine("Nombre de jugador: {0}", name);
            Console.WriteLine("El rol del jugador es: {0}", role);
            Console.WriteLine("El nivel del jugador es: {0}", level);
            Console.WriteLine("------------------------------");
        }
    }
}
