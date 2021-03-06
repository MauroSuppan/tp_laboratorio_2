﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda el dato en un archivo Xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            XmlSerializer ser;
            XmlTextWriter writer;

            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                ser = new XmlSerializer(typeof(T));

                ser.Serialize(writer, datos);

                writer.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }


        /// <summary>
        /// Lee un archivo Xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos)
        {
            XmlSerializer ser;
            XmlTextReader reader;

            try
            {
                reader = new XmlTextReader(archivo);
                ser = new XmlSerializer(typeof(T));

                datos = (T)ser.Deserialize(reader);

                reader.Close();

                return true;
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
        }

    }
}
