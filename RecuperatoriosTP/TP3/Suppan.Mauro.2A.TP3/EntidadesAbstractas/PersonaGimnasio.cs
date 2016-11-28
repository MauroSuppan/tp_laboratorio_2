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

        /// <summary>
        /// Constructor utilizado par serializacion
        /// </summary>
        public PersonaGimnasio()
        {

        }

        /// <summary>
        /// Constructor que crea una nueva PersonaGimnasio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        /// <summary>
        /// Compara si dos PersonaGimnasio son iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this == (PersonaGimnasio)obj;
        }

        /// <summary>
        /// Devuelve todos los datos de la PersonaGimnasio y llama al base
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NUMERO: " + this._identificador);
            return sb.ToString();
        }


        /// <summary>
        /// Compara si dos PersonaGimnasio son distintas
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);

        }
        /// <summary>
        /// Compara si dos PersonaGimnasio son iguales si y solo si son del mismo Tipo y su ID o DNI son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si son iguales</returns>
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

        /// <summary>
        /// Metodo abtracto para participara en clase 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();




    }
}
