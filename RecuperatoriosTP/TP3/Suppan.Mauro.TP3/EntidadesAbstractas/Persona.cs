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
            Extranjero,
        }
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDni(this._nacionalidad, value);

            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }


        public string StringToDNI
        {
            set
            {
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this (nombre , apellido, nacionalidad)
        {
            this.DNI = dni  ;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad): this(nombre , apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ( nacionalidad == ENacionalidad.Argentino)
            {
                if (dato >=1 && dato <=89999999 )
                {
                    return dato;
                }
            }
            else
            {
                if (dato <=90000000 && dato >= 99999999)
                {
                    return dato;
                }

                
            }
            throw new DniInvalidoException()  ;
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
                    return "String no válido.";
                }
            }
            return dato;
           
        }




    }
}
