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
            AlDia,
        }

        private EClases _claseQueToma;
        private EEstadoCuenta _estaCuenta;

        public Alumno ()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma) : base (id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estaCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
           
        }


        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            
           if (a._claseQueToma != clase)   
                return true ;
            return false ;
        }

        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {

            //if (a._claseQueToma == clase && a._estaCuenta == EEstadoCuenta.Deudor)
            //    return true;
            //return false;

            if (!(clase != a._claseQueToma))
            {
                if (a._estadoCuenta != EEstadoCuenta.Deudor)
                    return true;
            }
            return false;
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }


    }
}
