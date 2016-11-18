using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : PersonaGimnasio
    {
        private EClases _claseQueToma;
        private EEstadoCuenta _estaCuenta;

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
        {
        }

        protected override string MostrarDatos()
        {
           
            StringBuilder sb = new StringBuilder();
             //sb.AppendLine( this.ToString());
            
            
            sb.AppendLine(this.ParticiparEnClase());
            sb.AppendLine(" Esta clase: " + this._estaCuenta);
            return sb.ToString();
           
        }


        public static bool operator !=(Alumno a, EClases clase)
        {
            
           if (a._claseQueToma != clase)   
                return true ;
            return false ;
        }

        public static bool operator ==(Alumno a, EClases clase)
        {

            if (a._claseQueToma == clase && a._claseQueToma == Deudor)
                return true;
            return false;
        }

        protected string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine ("TOMA CLASE DE "+ this._claseQueToma);
            return sb.ToString();
        }

        public string ToString()
        {
           return  this.MostrarDatos();
        }


    }
}
