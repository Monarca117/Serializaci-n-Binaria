using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Formatters.Binary;  //El formateador binario toma la información de la memoria bit pot bi y lo guarda.
using System.IO; //Es usado para tener los mecanismos de entrada y salida

namespace SBJugador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            String valor = "";

            Console.WriteLine("1.- Crear y serializar jugador, 2.- Leer jugador");
            valor = Console.ReadLine();
            opcion = Convert.ToInt32(valor);

            if (opcion == 1)
            {
                //Creamos el objeto auto
                string name = "";
                string role = "";
                int level = 0;

                Console.WriteLine("Escribe el nombre del jugador");
                name = Console.ReadLine();

                Console.WriteLine("Escribe tu rol ");
                role = Console.ReadLine();

                Console.WriteLine("Escribe el nivel del jugador");
                valor = Console.ReadLine();
                level = Convert.ToInt32(valor);

                CJugador miJugador = new CJugador(name, role, level);

                Console.WriteLine("Jugador a serializar");
                miJugador.MuestraInformacion();

                //Empezamos la serialización
                Console.WriteLine("---SERIALIZANDO---");

                //
                BinaryFormatter formateador = new BinaryFormatter();

                //Creamos el stream
                Stream miStream = new FileStream("Jugador.jug", FileMode.Create, FileAccess.Write, FileShare.None);

                //Serializamos
                formateador.Serialize(miStream, miJugador);

                //Cerramos el stream
                miStream.Close();
            }

            if (opcion == 2)
            {
                //Deserializamos el objeto
                Console.WriteLine("---DESERIALIZAMOS---");

                //Seleccionamos el formateador
                BinaryFormatter formateador = new BinaryFormatter();

                //Creamos el stream
                Stream miStream = new FileStream("Jugador.jug", FileMode.Open, FileAccess.Read, FileShare.None);

                //Deserializamos
                CJugador miJugador = (CJugador)formateador.Deserialize(miStream);

                //Cerramos el stream
                miStream.Close();

                //Usamos el objet
                Console.WriteLine("El jugador deserializado es ");
                miJugador.MuestraInformacion();

            }
        }
    }
}
