using System;
using System.Collections.Generic;
using System.Text;


namespace ProyectoEscuela.Entidades
{
    public class Evaluaciones : ObjetoEscuelaBase
    {


        public Alumno Alumno { get; set; }
        public Asignaturas Asignatura { get; set; }

        public float Nota { get; set; }


        public override string ToString()
        {
            return $"{Nota},{Alumno.Nombre},{Asignatura.Nombre}";
        }

    }
}
