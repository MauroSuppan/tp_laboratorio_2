using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        ///   /// <summary>
        /// Constructor por defecto. Pasa un mensaje fijo al base
        /// </summary>
        /// </summary>
        public NacionalidadInvalidaException()
            : base("La nacionalidad no se condice con el número de DNI.")
        {

        }

        /// <summary>
        /// Constructor que recibe un mensaje como parámetro y se lo pasa al base
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message)
            : base(message)
        {

        }

    }
}
