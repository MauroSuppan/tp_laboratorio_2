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


        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        public static bool Guardar(Gimnasio gim)
        {
            string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gimnasio.xml";

            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();

            xmlFile.guardar(pathXml, gim);

            return true;
        }

        public static Gimnasio Leer()
        {
            string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gimnasio.xml";
            Gimnasio auxGimnasio;

            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();

            xmlFile.leer(pathXml, out auxGimnasio);

            return auxGimnasio;
        }
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < gim._jornada.Count; i++)
            {
                sb.AppendLine(gim[i].ToString());
            }

            return sb.ToString();
        }

        public static bool operator !=(Gimnasio g, Alumno a)
        {
            if (g == a)
                return false;
            return true;
        }

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

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            if (g == i)
                return false;
            return true;
        }

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

        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, (g == clase));
            foreach (Alumno item in g._alumnos)
            {
                if (item == clase)
                {
                    nuevaJornada = nuevaJornada + item;
                }
            }
            g._jornada.Add(nuevaJornada);
            return g;
        }

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


        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

       







    }
}
