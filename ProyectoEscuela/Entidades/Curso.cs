using ProyectoEscuela.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEscuela.Entidades
{
     public class Curso : ObjetoEscuelaBase, ILugar
    {
        
        public TipoJornada Jornada { get; set; }
        public List<Asignaturas> Asignatura { get; set; }
        public List<Alumno> Alumno { get; set; }
        public List<Evaluaciones> Evaluacion { get; set; }
        public string Direccion { get; set; }
        

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Nombre} Limpio");
        }
        //public Curso()
        //{
        //    UniqueID = Guid.NewGuid().ToString();

        //}


    }


}
    
