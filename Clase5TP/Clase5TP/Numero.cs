using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clase5TP
{
    class Numero
    {
        private double numero;

      
        
        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// llama al constructor que recibe un double e inicializa a numero en 0
        /// </summary>
        public Numero() :this((double) 0)
        {
           
        }
        /// <summary>
        /// recibe un double y se lo asigna numero
        /// </summary>
        /// <param name="numero">Valor a asignar</param>
        public Numero(double numero)
        {
            this.numero = numero;  
        }
        /// <summary>
        /// recibe un string que se va a validar y asignar
        /// </summary>
        /// <param name="numero">numero a validar</param>
        public Numero(string numero)
        {
           
            this.setNumero(numero);
        }
        /// <summary>
        /// valida y setea el valor
        /// </summary>
        /// <param name="numero">string a validar</param>
        private void setNumero(string numero)
        {
           

            this.numero = Numero.ValidarNumero(numero);
            

        }

        /// <summary>
        /// convierte un string a double, en caso de no poder retorna 0
        /// </summary>
        /// <param name="numeroString">string a convertir</param>
        /// <returns>retorna un double</returns>
        private static double ValidarNumero(string numeroString)
        {
         
            double numeroDouble;
            if (double.TryParse(numeroString, out numeroDouble))
                return numeroDouble;
            return 0;
        }

        //sobrecarga del operador +
        public static double operator +(Numero num1, Numero num2)
        {
            double retValue;
            retValue = num1.numero + num2.numero;
            return retValue;

        }
        //sobrecarga del operador -
        public static double operator -(Numero num1, Numero num2)
        {
            double retValue;
            retValue = num1.numero - num2.numero;
            return retValue;

        }
        //sobrecarga del operador*
        public static double operator *(Numero num1, Numero num2)
        {
            double retValue;
            retValue = num1.numero * num2.numero;
            return retValue;

        }
        //sobrecarga del operador /
        public static double operator /(Numero num1, Numero num2)
        {
            double retValue;
            retValue = num1.numero / num2.numero;
            return retValue;

        }


    }
}
