using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string _nombre;
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;

        public string Apellido
        {
            set
            {
                this._apellido = this.ValidarNombreApellido(value);
            }
            get
            {
                return this._apellido;
            }
        }
       
        public string Nombre
        {
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
            get
            {
                return this._nombre;
            }
        }
        
        public int DNI
        {
            set
            {
                this._dni = this.ValidarDni(this.Nacionalidad, value);
            }
            get
            {
                return this._dni;
            }
        }
       
        public ENacionalidad Nacionalidad
        {
            set
            {
                this._nacionalidad = value;
            }
            get
            {
                return this._nacionalidad;
            }
        }
        public string StringToDNI
        {
            set
            {
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
            }
        }


        /// <summary>
        /// Constructor usado para la serializacion
        /// </summary>
        public Persona()
        {

        }
     
        /// <summary>
        /// Constructor que crea una nueva Persona sin DNI
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor que crea una nueva Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor que crea una nueva Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

   
        /// <summary>
        /// Valida que el dni corresponda con la nacionalidad y esté dentro del rango correcto.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>Devuelve el DNI ya validado.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if ((dato >= 1) && (dato <= 89999999))
                {
                    return dato;
                }
            }
            else
            {
                if ((dato >= 90000000) && (dato <= 99999999))
                {
                    return dato;
                }
            }

            throw new DniInvalidoException();
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                return int.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(e);
            }

        }

        private string ValidarNombreApellido(string dato)
        {
            foreach (Char item in dato)
            {
                if (!Char.IsLetter(item) && item != 32)
                {
                    return "Cadena no válida.";
                }
            }
            return dato;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());

            return sb.ToString();
        }
        
    }
}
