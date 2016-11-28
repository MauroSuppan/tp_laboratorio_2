using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno : PersonaGimnasio
    {
        public enum EEstadoCuenta
        {
            MesPrueba,
            Deudor,
            AlDia
        }

      
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        /// <summary>
        /// Constructor usado para la serializacion
        /// </summary>
        public Alumno()
        {

        }
      
       
    /// <summary>
    /// Constructor que crea un nuevo alumno.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="nombre"></param>
    /// <param name="apellido"></param>
    /// <param name="dni"></param>
    /// <param name="nacionalidad"></param>
    /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        
     /// <summary>
        /// Constructor que crea un nuevo alumno con el estado de la cuenta
     /// </summary>
     /// <param name="id"></param>
     /// <param name="nombre"></param>
     /// <param name="apellido"></param>
     /// <param name="dni"></param>
     /// <param name="nacionalidad"></param>
     /// <param name="claseQueToma"></param>
     /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

      

       
        /// <summary>
        /// Devuelve todos los datos del alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve la clase que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma.ToString();
        }

        /// <summary>
        /// Devuelve todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
       

      
        /// <summary>
        /// Compara si el alumno no toma la clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (clase != a._claseQueToma)
                return true;
            return false;
        }

        /// <summary>
        /// Compara si el alumno toma la clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (!(clase != a._claseQueToma))
            {
                if (a._estadoCuenta != EEstadoCuenta.Deudor)
                    return true;
            }
            return false;
        }
       
    }
}
