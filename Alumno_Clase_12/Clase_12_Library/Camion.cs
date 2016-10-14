using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_12_Library_2;


namespace Clase_12_Library
{
    public class Camion : Vehiculo
    {
        /// <summary>
        /// constructor publico de Camion // llama al constructor base
        /// </summary>
        /// <param name="marca">marca de moto</param>
        /// <param name="patente">patente de moto</param>
        /// <param name="color">color de moto</param>
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
        }
        /// <summary>
        /// Los camiones tienen 8 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 8;
            }
        }
        /// <summary>
        /// muestra todos los datos de la moto
        /// </summary>
        /// <returns>retorna los datos de la moto</returns>
       public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString ();
        }
    }
}
