using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProyectoEscuela.Util
{
   public  static class Printer
    {


        public static void DrawLine( int tam =10)
        {
            var Linea = "".PadLeft(tam, '=');
            WriteLine(Linea);

        }


        public static void WriteTitle(String titulo)


        {
            var tam = titulo.Length + 4;
            DrawLine(tam);
            WriteLine($" | {titulo} | ");
            DrawLine(tam);
            

        }


        public static void Beep(int hz = 2000 ,int tiempo = 500, int cantidad = 1 )



        {
        
            while(cantidad-- > 0){


                Console.Beep(hz, tiempo);

                                }// end while
            

        }



    }
}
