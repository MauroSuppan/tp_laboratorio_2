using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables 
{
    public sealed class Instructor : PersonaGimnasio 
    {
        private Queue<EClases> _clasesDelDia;
        private static Random _random;

        private void _randomClases()
        {
        }

         static Instructor()
        {
            _random = new Random();
        }


        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
        {

        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
        }

        public static bool operator !=(Instructor i, EClases clase)
        {
        }

        public static bool operator ==(Instructor i, EClases clase)
        {
        }

        protected string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("CLASES DEL DIA "+ this.
        }

        public string ToString()
        {
        }






    }
}
