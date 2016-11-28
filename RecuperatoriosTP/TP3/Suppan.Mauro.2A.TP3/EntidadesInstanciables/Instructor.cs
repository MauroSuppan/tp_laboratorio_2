using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Instructor : PersonaGimnasio
    {
       
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;
        

       
        /// <summary>
        /// Constructor de clase que inicializa el random.
        /// </summary>
        static Instructor()
        {
            _random = new Random();
        }

        /// <summary>
        /// Constructor que crea un nuevo instructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Constructor usado para la serializacion
        /// </summary>
        public Instructor()
        {

        }
    

        
        /// <summary>
        /// Devuelve todos los datos del instructor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve todas las clases que da el instructor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve todos los datos del instructor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Genera aleatoriamente clases que da el instructor
        /// </summary>
        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 4));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 4));
        }
        

        /// <summary>
        /// Compara si el instructor da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si el instructor da la clase</returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Compara si el instructor no da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si el instructor no da la clase</returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }
       
    }
}
