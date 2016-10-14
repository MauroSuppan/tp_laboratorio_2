using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_12_Library_2;

namespace Clase_12_Library
{
    public class Automovil : Vehiculo
    {
        /// <summary>
        /// Constructor publico de Automovil, llama al constructor base
        /// </summary>
        /// <param name="marca">marca del automovil</param>
        /// <param name="patente">patente del automovil</param>
        /// <param name="color">color del automovil</param>
        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
        }
        /// <summary>
        /// Los automoviles tienen 4 ruedas
        /// </summary>
       public override short CantidadRuedas
        {
            get
            {
                return 4;
            }
        }

        /// <summary>
        /// Muestra los datos del automovil
        /// </summary>
        /// <returns>retorna los datos del automovil</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString ();
        }
    }
}
