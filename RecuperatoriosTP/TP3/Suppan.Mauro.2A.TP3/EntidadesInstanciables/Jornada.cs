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
        private Gimnasio.EClases _clase;
        private Instructor _instructor;
        

   
        /// <summary>
        /// Constructor por defecto que inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que inicializa la clase y al instructor que recibe como parametros
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        

       
        /// <summary>
        /// Datos de la jornada
        /// </summary>
        /// <returns>Datos completos de la jornada</returns>
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

        /// <summary>
        /// Guarda la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>true si guardo exitosamente</returns>
        public static bool Guardar(Jornada jornada)
        {
            string pathTexto = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";

            Texto text = new Texto();

            text.guardar(pathTexto, jornada.ToString());

            return true;
        }

        /// <summary>
        /// Lee la jornada que se guardo en un archivo de texto y la devuelve como string
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string pathTexto = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";
            string aux;

            Texto text = new Texto();

            text.leer(pathTexto, out aux);

            return aux;
        }
      

      
        /// <summary>
        /// Compara si el alumno participa de la clase de la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j._clase);
        }

        /// <summary>
        /// Compara si el alumno no participa de la clase de la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada, si no fue ingresado antes
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
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
    
    }
}
