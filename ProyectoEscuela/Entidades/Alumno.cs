using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEscuela.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
        //public string UniqueId { get; private set; }
        //public string Nombre { get; set; }
        public List<Evaluaciones> Evaluacional { get; set; } = new List<Evaluaciones>(); 

        



        //public Alumno()
        //{
        //    UniqueId = Guid.NewGuid().ToString();
        //    Evaluacional = new List<Evaluaciones>();
        //}

    }


    
}
