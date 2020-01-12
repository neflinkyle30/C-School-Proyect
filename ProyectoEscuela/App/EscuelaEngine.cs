using ProyectoEscuela.Entidades;
using ProyectoEscuela.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoEscuela.App
{
    public sealed class EscuelaEngine
    {

        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {


        }


        public void Inicializar()
        {
            Escuela = new Escuela("Learning code", 2019, ClsTipoEscuela.Primaria, pais: "El Salvador");

            CargarCursos();
            CargarAsignaturas();
            //GenerarEvaluaciones();
            CargarEvaluaciones();

        }










        private List<Evaluaciones> GenerarEvaluaciones(int cantidad)
        {
            List<Evaluaciones> listaevaluaciones = new List<Evaluaciones>() {

                new Evaluaciones() { Nombre = "Examen Escrito" },
                new Evaluaciones() { Nombre = "Foro Libre" },
                new Evaluaciones() { Nombre = "Tarea Analisis" },
                new Evaluaciones() { Nombre = "Presentacion de Proyecto" },
                new Evaluaciones() { Nombre = "Avance Proyecto I" },
                new Evaluaciones() { Nombre = "Debate" },
                new Evaluaciones() { Nombre = "Proyecto Final" },
                new Evaluaciones() { Nombre = "Examen Oral" }

                                                       }; // fin lista

            return listaevaluaciones.OrderBy((al) => al.UniqueIDA).Take(cantidad).ToList();




        }





        private List<Alumno> GenerarAlumnos(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueIDA).Take(cantidad).ToList();

        }



        //Imprimiendo Diccionario 

        public void ImprimirDiccionario(Dictionary<LlaveDiccionrio, IEnumerable<ObjetoEscuelaBase>> dic, bool impEval = false ) {

            foreach (var objeto in dic)
            {
                Printer.WriteTitle(objeto.Key.ToString());

                foreach (var key in objeto.Value)
                {

                    switch (key)
                    {
                        case LlaveDiccionrio.Evaluacione:
                            break;
                        default:            LlaveDiccionrio         
                            
                    }

                    //if (val is Evaluaciones)
                    //{
                    //    if (impEval)
                    //    {
                    //        Console.WriteLine("Nota : "+ val);
                    //    }

                    //}
                    //else if(val is Escuela)
                    //{
                    //    Console.WriteLine("Escuela : "+ val);
                    //}
                    //else if (val is Alumno)
                    //{
                    //    Console.WriteLine("Alumno : " + val.Nombre);
                    //} else
                    //{
                    //    Console.WriteLine(val);


                    //}
                 
                }
            }


        }
        
        //New Diccionario 



        public Dictionary<LlaveDiccionrio, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {


            var NewDic = new Dictionary<LlaveDiccionrio, IEnumerable<ObjetoEscuelaBase>>();
            NewDic.Add(LlaveDiccionrio.Escuela, new[] { Escuela });
            NewDic.Add(LlaveDiccionrio.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            var listtmp = new List<Evaluaciones>();
            var listtmpA = new List<Asignaturas>();
            var listtmpAL = new List<Alumno>();
            foreach (var cur in Escuela.Cursos)
            {
                listtmpA.AddRange(cur.Asignatura);
                listtmpAL.AddRange(cur.Alumno);


                foreach (var al in cur.Alumno)
                {

                    listtmp.AddRange(al.Evaluacional);

                }
                


            }
            NewDic.Add(LlaveDiccionrio.Asignatura, listtmpA);
            NewDic.Add(LlaveDiccionrio.Alumno, listtmpAL);
            NewDic.Add(LlaveDiccionrio.Evaluacione, listtmp);


            return NewDic;

        }



        //Sobrecarga de metodo  sin ningun conteo
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(bool bringEvaluations = true, bool bringStudents = true, bool bringAsignaturas = true, bool bringCursos = true)
        {


            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        //Sobrecarga de metodo con solo conteo evaluaciones
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int CountEvaluations, bool bringEvaluations = true, bool bringStudents = true, bool bringAsignaturas = true, bool bringCursos = true)
        {


            return GetObjetosEscuela(out CountEvaluations, out int dummy, out dummy, out dummy);
        }


        //Sobrecarga de metodo para que devuelva evaluaciones y cursos
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int CountEvaluations, out int CountCursos, bool bringEvaluations = true, bool bringStudents = true, bool bringAsignaturas = true, bool bringCursos = true)
        {


            return GetObjetosEscuela(out CountEvaluations, out CountCursos, out int dummy, out dummy);
        }

        //Sobrecarga de metodo para que devuelva evaluaciones,cursos y Asignaturas
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int CountEvaluations, out int CountCursos, out int CountAsignaturas, bool bringEvaluations = true, bool bringStudents = true, bool bringAsignaturas = true, bool bringCursos = true)
        {


            return GetObjetosEscuela(out CountEvaluations, out CountCursos, out CountAsignaturas, out int dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int CountEvaluations,
            out int CountStudents,
            out int CountAsignaturas,
            out int CountCursos,
            bool bringEvaluations = true, bool bringStudents = true, bool bringAsignaturas = true, bool bringCursos = true)
        {

            CountEvaluations = CountStudents = CountAsignaturas = CountCursos = 0;
            var listaObj = new List<ObjetoEscuelaBase>();

            listaObj.Add(Escuela);
            if (bringCursos) { listaObj.AddRange(Escuela.Cursos); CountCursos = Escuela.Cursos.Count; }


            foreach (var curso in Escuela.Cursos)
            {
                if (bringStudents) { listaObj.AddRange(curso.Alumno); CountStudents += curso.Alumno.Count; }
                if (bringAsignaturas) { listaObj.AddRange(curso.Asignatura); CountAsignaturas += curso.Asignatura.Count; }


                if (bringEvaluations)
                {


                    foreach (var alumno in curso.Alumno)
                    {
                        listaObj.AddRange(alumno.Evaluacional);
                        CountEvaluations += alumno.Evaluacional.Count;
                    }

                }
            }


            return listaObj.AsReadOnly();

        }





        #region Diccionarios



        #endregion




        #region Metodos de Carga

        private void CargarAsignaturas()
        {

            foreach (var curso in Escuela.Cursos)
            {
                List<Asignaturas> listaAsignaturas = new List<Asignaturas>() {

                new Asignaturas() { Nombre = "Matematicas" },
                new Asignaturas() { Nombre = "Educacion Fisica" },
                new Asignaturas() { Nombre = "Castellanos" },
                new Asignaturas() { Nombre = "Ciencias Naturales" },
                new Asignaturas   { Nombre = "Ingles" }
                                                }; // fin lista


                curso.Asignatura = listaAsignaturas;



            };

            Random rnd = new Random();



        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>() {

                new Curso() { Nombre = "101", Jornada = TipoJornada.Mañana  },
                new Curso() { Nombre = "201", Jornada = TipoJornada.Mañana  },
                new Curso(){ Nombre = "301" , Jornada = TipoJornada.Mañana},
                new Curso() { Nombre = "401", Jornada = TipoJornada.Tarde },
                new Curso   { Nombre = "501", Jornada = TipoJornada.Tarde  }

                                                }; // fin lista
            Random rnd = new Random();


            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumno = GenerarAlumnos(cantRandom);
            }
        }

        private double GenerarNota()
        {
            Random rnd = new Random();
            return rnd.NextDouble() * 5;
        }

        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {

                foreach (var asg in curso.Asignatura)
                {
                    foreach (var alumno in curso.Alumno)
                    {

                        var rnd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {

                            var ev = new Evaluaciones
                            {

                                Nombre = $"{asg.Nombre} Ev#{i + 1 }",
                                Asignatura = asg,

                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno


                            };
                            alumno.Evaluacional.Add(ev);

                            //asg.Evaluacion.Add(new Evaluaciones
                            //{

                            //    //Nombre = GenerarEvaluaciones(),
                            //    Alumno = alumno,
                            //    Asignatura = asg,
                            //    Nota = (float)Math.Round(GenerarNota(), 2, MidpointRounding.ToEven)

                            //});

                        }// End for

                    }
                }//End foreach Alumnos




            }// End foreach cursos
        }

        #endregion
    }
}
