using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;
using Archivos;
using EntidadesAbstractas;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(PersonaGimnasio))]
    [XmlInclude(typeof(Persona))]
    [Serializable]
    public class Gimnasio
    {
        public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates,
            Yoga
        }

        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
        }

        public List<Instructor> Instructores
        {
            get
            {
                return this._instructores;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this._jornada[i];
            }
        }

        /// <summary>
        /// Constructor por defecto. Inicializa las listas de alumnos, instructores y jornadas
        /// </summary>
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        /// <summary>
        /// Guarda el gimnasio en un archivo Xml
        /// </summary>
        /// <param name="gim"></param>
        /// <returns>true si guardo correctamente</returns>
        public static bool Guardar(Gimnasio gim)
        {
            string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gimnasio.xml";

            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();

            xmlFile.guardar(pathXml, gim);

            return true;
        }

        /// <summary>
        /// Lee el gmnasio que se guardo en el archivo Xml
        /// </summary>
        /// <returns></returns>
        public static Gimnasio Leer()
        {
            string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gimnasio.xml";
            Gimnasio auxGimnasio;

            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();

            xmlFile.leer(pathXml, out auxGimnasio);

            return auxGimnasio;
        }
        /// <summary>
        /// Devuelve todos los datos del Gimnasio
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < gim._jornada.Count; i++)
            {
                sb.AppendLine(gim[i].ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Compara si el alumno no esta en el gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true si el alumno no es esta en el gimnasio</returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            if (g == a)
                return false;
            return true;
        }

        /// <summary>
        /// Compara si el alumno esta inscripto en el gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>True si el alumno se encuentra en el gimnasio</returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            bool estado = false;
            foreach (Alumno item in g._alumnos)
            {
                if (item.DNI == a.DNI)
                {
                    estado = true;
                    break;
                }
            }
            return estado;
        }


        /// <summary>
        /// Devuelve el primer instructor que no de la clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            int i;
            bool estado = false;
            for (i = 0; i < g._instructores.Count; i++)
            {
                if (g._instructores[i] != clase)
                {
                    estado = true;
                    break;
                }
            }
            if (estado)
                return g._instructores[i];
            throw new SinInstructorException();
        }

        /// <summary>
        /// Devuelve un instructor que de la clase pasada por parametro, caso que no haya lanza una interrupcion
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            int i;
            bool estado = false;
            for (i = 0; i < g._instructores.Count; i++)
            {
                if (g._instructores[i] == clase)
                {
                    estado = true;
                    break;
                }
            }
            if (estado)
                return g._instructores[i];
            throw new SinInstructorException();
        }

        /// <summary>
        /// Compara un gimnasio con un instructor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>True si el instructor no se encuentra en el gimnasio</returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            if (g == i)
                return false;
            return true;
        }

        /// <summary>
        /// Compara un gimnasio con un instructor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>True si el instructor se encuentra en el gimnasio</returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            bool estado = false;
            foreach (Instructor item in g._instructores)
            {
                if (item == i)
                {
                    estado = true;
                    break;
                }
            }
            return estado;
        }

        /// <summary>
        /// Agrega un alumno si no fue cargado anteriormente
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a">gimnasio con el alumno agregado</param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            bool estado = true;
            foreach (Alumno item in g._alumnos)
            {
                if (item == a)
                {
                    estado = false;
                    break;
                }
            }
            if (estado)
            {
                g._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
        }

        /// <summary>
        /// Genera una nueva jornada en el gimnasio con la clase dada
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Gimnasio con la jornada generada</returns>
        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            Jornada nueva = new Jornada(clase, (g == clase));
            foreach (Alumno item in g._alumnos)
            {
                if (item == clase)
                {
                    nueva = nueva + item;
                }
            }
            g._jornada.Add(nueva);
            return g;
        }

        /// <summary>
        /// Agrega un instructor, siempre que no haya sido agregado antes
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            bool estado = true;
            foreach (Instructor item in g._instructores)
            {
                if (item == i)
                {
                    estado = false;
                    break;
                }
            }
            if (estado)
            {
                g._instructores.Add(i);
            }
            return g;
        }


        /// <summary>
        /// Devuelve todos los datos del gimnasio
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }









    }
}
