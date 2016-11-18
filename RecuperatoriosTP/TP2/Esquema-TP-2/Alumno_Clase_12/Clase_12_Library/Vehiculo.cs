using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_12_Library;
//
namespace Clase_12_Library_2
{
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Yamaha, Chevrolet, Ford, Iveco, Scania, BMW
        }
        EMarca _marca;
        string _patente;
        ConsoleColor _color;

        /// <summary>
        /// retorna la cantidad de ruedas del vehiculo
        /// </summary>
        public abstract short CantidadRuedas { get; }

        /// <summary>
        /// constructor por defecto para crear un Vehiculo
        /// </summary>
        /// <param name="patente">patente del vehiculo</param>
        /// <param name="marca">marca</param>
        /// <param name="color">color</param>
        public Vehiculo(string patente, EMarca marca, ConsoleColor color)
        {
            this._patente = patente;
            this._marca = marca;
            this._color = color;
        }

        /// <summary>
        /// Muestra los datos del Vehiculo
        /// </summary>
        /// <returns>datos del Vehiculo</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehículos son iguales si comparten la misma patente
        /// </summary>
        /// <param name="v1">Vehiculo 1</param>
        /// <param name="v2">Vehículo 2</param>
        /// <returns>True si son iguales, False si son distintos</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (String.Compare(v1._patente, v2._patente) == 0);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su patente es distinta
        /// </summary>
        /// <param name="v1">Vehiculo 1</param>
        /// <param name="v2">Vehiculo 2</param>
        /// <returns>True si son distintos, False si son iguales</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
