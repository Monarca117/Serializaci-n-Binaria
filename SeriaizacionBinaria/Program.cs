using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Formatters.Binary;  //El formateador binario toma la información de la memoria bit pot bi y lo guarda.
using System.IO; //Es usado para tener los mecanismos de entrada y salida

namespace SeriaizacionBinaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            String valor = "";

            Console.WriteLine("1) Crear y serializar auto, 2) Leer auto");
            valor = Console.ReadLine();
            opcion = Convert.ToInt32(valor);

            if (opcion == 1) 
            {
                //Creamos el objeto auto
                string modelo = "";
                double costo = 0;

                Console.WriteLine("Dame el modelo");
                modelo = Console.ReadLine();

                Console.WriteLine("Dame el costo");
                valor = Console.ReadLine();
                costo = Convert.ToDouble(valor);

                CAuto miAuto = new CAuto(costo, modelo);

                Console.WriteLine("Auto a serializar");
                miAuto.MuestraInformacion();

                //Empezamos la serialización
                Console.WriteLine("---SERIALIZANDO---");

                //
                BinaryFormatter formateador = new BinaryFormatter();

                //Creamos el stream
                Stream miStream = new FileStream("Autos.aut", FileMode.Create, FileAccess.Write, FileShare.None);

                //Serializamos
                formateador.Serialize(miStream, miAuto);

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
                Stream miStream = new FileStream("Autos.aut", FileMode.Open, FileAccess.Read, FileShare.None);

                //Deserializamos
                CAuto miAuto = (CAuto)formateador.Deserialize(miStream);

                //Cerramos el stream
                miStream.Close ();

                //Usamos el objeto
                Console.WriteLine("El auto deserializado es ");
                miAuto.MuestraInformacion ();

            }
        }
    }
}
