using ProyectoEscuela.App;
using ProyectoEscuela.Entidades;
using ProyectoEscuela.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
namespace ProyectoEscuela
{
    class Program
    {
        static void Main(string[] args)
        {

            //Objeto
            var engine = new EscuelaEngine();
            //Inicializarlo
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            // Crear arreglo de objetos
           // Printer.Beep();
            
            ImprimirCursosEscuela(engine.Escuela);
            var listaObjetos = engine.GetObjetosEscuela(out int CountEvaluations,
            out int CountStudents,
            out int CountAsignaturas,
            out int CountCursos);

            Dictionary<int, string> diccionario = new Dictionary<int, string>();

            diccionario.Add(10, "JuanK");
            diccionario.Add(23, "Lorem ipsun");
            //engine.Escuela.LimpiarLugar();

            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key} Valor : {keyValPair.Value}");

            }

            var dictmp = engine.GetDiccionarioObjetos();

            engine.ImprimirDiccionario(dictmp);

            
            // Dictionary<int, string> diccionario = new Dictionary<int, string>();
            //diccionario.Add(10, "Juanca");
            //diccionario.Add(23, "Lorem Ipsum");


            //foreach (var keyVlaPair in diccionario)
            //{
            //    Console.WriteLine($"Key: {keyVlaPair.Key} valor : {keyVlaPair.Value}");
            //}

            //Printer.WriteTitle("Acceso a Diccionario");
            //WriteLine(diccionario[23]);

            //Printer.WriteTitle("New Diccionario");

            //var dic = new Dictionary<string, string>();
            //dic["Luna"] = "Cuerpo celeste que gira alrededor de la tierra";
            //WriteLine(dic["Luna"]);
            //dic.Add("Luna", "La protagonista de Soy luna");
            //WriteLine(dic["Luna"]);

            ////var listaIlugar = from obj in listaObjetos where obj is ILugarñ
            ////                  select (ILugar)obj;
            ///




            ReadKey();
        }

      /// <summary>
      /// Metodo para imprimir el resultado en la consola
      /// </summary>
      /// <param name="escuela"></param>

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos Escuela");

            // este es una opcion if (escuela != null && escuela.Cursos != null)
            if (escuela?.Cursos !=null)
            {

                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, ID {curso.UniqueIDA}");
                   
                }
            }
            else
            {

                return;

           

            }
        }

    
    }
}   
