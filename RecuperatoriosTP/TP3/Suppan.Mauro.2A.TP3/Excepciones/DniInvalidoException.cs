﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        ///  Constructor por defecto. Pasa un mensaje fijo al base
        /// </summary>
        public DniInvalidoException()
            : this("La nacionalidad no se condice con el número de DNI.")
        {

        }

        /// <summary>
        /// Constructor que pasa la excepción recibida como parámetro y un mensaje fijo al base.
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e)
            : base("La nacionalidad no se condice con el número de DNI.", e)
        {
            throw new NacionalidadInvalidaException();
        }

        /// <summary>
        /// Constructor que recibe un mensaje como parámetro y se lo pasa al base.
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message)
            : base(message)
        {
            throw new NacionalidadInvalidaException();
        }

        /// <summary>
        /// Constructor que recibe un mensaje y una excepción como parámetros. Pasa al base la excepción.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e)
            : this(e)
        {

        }

    }
}
