using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private  Gimnasio.EClases _clase;
        private Instructor _instructor;

        public Jornada this[int i]
        {
            get
            {

            }
        }

        public static bool Guardar(Jornada jornada)
        {
            string pathTexto = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";

            Texto text = new Texto();

            text.guardar(pathTexto, jornada.ToString());

            return true;         

        }

        public static string Leer(Jornada jornada)
        {
            string pathTexto = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";
            string aux;

            Texto text = new Texto();

            text.leer(pathTexto, out aux);

            return aux;
        }


        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }


        public Jornada(Gimnasio.EClases clase, Instructor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;

        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static bool operator +(Jornada j, Alumno a)
        {
            bool estado = true;
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                {
                    estado = false;
                    break;
                }
            }
            if (estado)
            {
                j._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;

        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j._clase);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.Append("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<---------------------------------------------------------------->");

            return sb.ToString();

        }


    }
}
