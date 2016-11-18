using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Clase_12_Library_2;

namespace Clase_12_Library
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Constructor por defecto publico  para crear una moto // llama al construcor base
        /// </summary>
        /// <param name="marca">marca de la moto</param>
        /// <param name="patente">patente de la moto</param>
        /// <param name="color">color de la moto</param>
        public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Las motos tienen 2 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Muestra los datos de la moto
        /// </summary>
        /// <returns>retorna los datos de la moto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
