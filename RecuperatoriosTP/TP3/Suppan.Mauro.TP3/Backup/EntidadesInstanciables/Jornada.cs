using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesInstanciables
{
    class Jornada
    {
        private List<Alumno> _alumnos;
        private EClases _clase;
        private Instructor _instructor;

        public Jornada this[int i]
        {
            get
            {

            }
        }

        public bool Guardar(Jornada jornada)
        {
        }

        public Jornada()
        {
        }


        public Jornada(EClases clase, Instructor instructor)
        {
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
        }

        public static bool operator +(Jornada j, Alumno a)
        {
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
        }

        public string ToString()
        {
        }


    }
}
