using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class PersonaGimnasio : Persona
    {
        private int _identificador;

        public PersonaGimnasio()
        {

        }
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        public override bool Equals(object obj)
        {
            return this == (PersonaGimnasio)obj;
        }


        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
           sb.AppendLine ("Identificador: " +this._identificador);
           return sb.ToString ();
        }


        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
              
        }
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.GetType() == pg2.GetType())
            {
                if (pg1._identificador == pg2._identificador)
                    return true;
                if (pg1.DNI == pg2.DNI)
                    return true;
            }
            return false;
        }


        protected abstract string ParticiparEnClase();
        



    }
}
