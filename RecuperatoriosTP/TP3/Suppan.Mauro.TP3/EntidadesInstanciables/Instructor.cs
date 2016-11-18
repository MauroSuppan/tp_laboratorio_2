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
        private Queue<Alumno.EClases> _clasesDelDia;
        private static Random _random;

        public Instructor()
        {

        }
        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 4));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 4));
        }

         static Instructor()
        {
            _random = new Random();
        }


        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base (id,nombre,apellido,dni,nacionalidad)
        {
            _clasesDelDia = new Queue<Alumno.EClases>();
            this._randomClases();
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }

        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA");
            //<Alumno.EClases> _clasesDelDia
            foreach (Alumno.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();

        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }






    }
}
