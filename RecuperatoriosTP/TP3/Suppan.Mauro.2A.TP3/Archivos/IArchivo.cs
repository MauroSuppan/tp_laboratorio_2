using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Guarda datos en un archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool guardar(string archivo, T datos);

        /// <summary>
        /// Lee datos de un archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool leer(string archivo, out T datos);

    }
}
