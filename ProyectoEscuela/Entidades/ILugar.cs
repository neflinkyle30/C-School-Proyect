using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEscuela.Entidades
{
   public  interface ILugar
    {
          string Direccion { get; set; }

    void LimpiarLugar();

    }
}
