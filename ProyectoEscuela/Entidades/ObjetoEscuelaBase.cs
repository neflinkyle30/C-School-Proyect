using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEscuela.Entidades
{
   public abstract  class ObjetoEscuelaBase
    {
        public string Nombre { get; set; }
        public string UniqueIDA { get; private set; }


        public ObjetoEscuelaBase() {

            UniqueIDA = Guid.NewGuid().ToString();

        }


        public override string ToString()
        {


            return $"{Nombre},{UniqueIDA}";
        }

    }
}
