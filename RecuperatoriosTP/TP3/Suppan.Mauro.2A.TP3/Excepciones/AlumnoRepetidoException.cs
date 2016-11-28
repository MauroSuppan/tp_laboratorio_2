using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto que pasa un mensaje
        /// </summary>
        public AlumnoRepetidoException()
            : base("Alumno repetido.")
        {

        }
    }
}
