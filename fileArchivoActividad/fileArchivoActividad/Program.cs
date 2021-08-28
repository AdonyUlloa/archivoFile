using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fileArchivoActividad
{
    class archivoClinico
    {
        static void Main()
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = Menu();
            }
        }
        private static bool Menu()
        {

            Console.WriteLine("REGISTRO CLINICO");
            Console.WriteLine("Selecionar operacion a realizar: ");
            Console.WriteLine("1. Registrar nuevo paciete: ");
            Console.WriteLine("2. Actualizar dato de paciente: ");
            Console.WriteLine("3. Eliminar dato de un paciente: ");
            Console.WriteLine("4. Mostrar listado de pacientes: ");
            Console.WriteLine("5. Salir: ");
            Console.Write("\nOpcion: ");

            switch (Console.ReadLine())
            {
                case "1":
                    registerPaciente();
                    return true;
                case "2":
                    return true;
                case "3":        
                    return true;
                case "4":
                    Console.WriteLine("LISTADO DE PACIENTES");
                    foreach (KeyValuePair<object, object> data in readFile())
                    {
                        Console.WriteLine("{0}: {1}", data.Key, data.Value);
                    }
                    Console.ReadKey();
                    return true;
                case "5":
                    return false;
                default:
                    return false;

            }
        }

        private static string getPath()
        {
            string path = @"C:\Users\PC\Desktop\tareaProgramacionArchivo\registro.txt";
            return path;
        }

        private static void registerPaciente()
        {
            Console.WriteLine("DATOS DEL PACIENTE");
            Console.Write("Nombre completo: ");
            string fullname = Console.ReadLine();
            Console.Write("Edad: ");
            int age = Convert.ToInt32(Console.ReadLine());

            using (StreamWriter sw = File.AppendText(getPath()))
            {
                sw.WriteLine("{0}; {1}", fullname, age);
                sw.Close();
            }
        }

        private static Dictionary<object, object> readFile()
        {
            Dictionary<object, object> listData = new Dictionary<object, object>();

            using (var reader = new StreamReader(getPath()))
            {
                string lines;

                while ((lines = reader.ReadLine()) != null)
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        listData.Add(keyvalue[0], keyvalue[1]);
                    }
                }
            }
            return listData;

        }

        private static bool search(string name)
        {
            if (!readFile().ContainsKey(name))
            {
                return false;
            }
            return true;
        }

    }
}
