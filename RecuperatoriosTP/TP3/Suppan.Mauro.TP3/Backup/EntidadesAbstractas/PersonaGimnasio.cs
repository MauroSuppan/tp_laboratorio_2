using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesInstanciables;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        private int _identificador;

        public bool Equals(object obj)
        {
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.ToString());
            Console.WriteLine (this._identificador);
        }


        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
              
        }

        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return (pg1.DNI == pg2.DNI);
               

        }

        protected abstract string ParticiparEnClase();
        

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }



    }
}
