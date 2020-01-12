using ProyectoEscuela.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar

    {

        string Nombre;



        // Encapsulamiento

        public int _AñoCreacion { get; set; }
        public string Pais { get; set; }
        private int myvar;
     
        public List<Curso> Cursos { get; set; }
        public List<Asignaturas> Asignatura {get; set;}
        public List<Alumno> Alumno { get; set; }
        public List<Evaluaciones> Evaluacion { get; set; }
        public ClsTipoEscuela TipoEscuela { get; set; }
        public string Direccion { get; set; }

        //Constructor
        /*public Escuela(string Nombre, int año)
        {
            this.Nombre = Nombre;
            _AñoCreacion = año;
        }

    */
        //Otra forma de setear constructor 
        public Escuela(string Nombre, int año) => (Nombre, _AñoCreacion) = (Nombre, año);
        public Escuela(string Nombre, int año, ClsTipoEscuela tipo,
                                                string pais = "")
        {

            (Nombre, _AñoCreacion) = (Nombre, año);
            Pais = pais;
             
        }

        public Escuela()
        {
        }

        public override string ToString()
        {
            return $"Nombre{Nombre},Tipo {TipoEscuela} \n Pais {Pais}";
        }


        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela...");
           
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Console.WriteLine($"Escuela {Nombre} Limpia");
            Printer.Beep(15000, cantidad: 3);
        }
    }
}
