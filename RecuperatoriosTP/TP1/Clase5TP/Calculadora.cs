using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clase5TP
{
    class Calculadora
    {
        /// <summary>
        /// realiza un operacion de 2 obejetos
        /// </summary>
        /// <param name="numero1">valor numero 1</param>
        /// <param name="numero2">valor numero 2</param>
        /// <param name="operador">operacion a realizar</param>
        /// <returns>retorna el resultado</returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
             double aux2 = 0; 

            //llama al metodo ValidarOperador e ingresa al case correspondiente y realiza la operacion
            operador = Calculadora.ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                {
                    aux2 = numero1 + numero2; 
                    break;
                }
                case "-":
                {
                    aux2 = numero1- numero2;
                
                    break;
                }
                case "*":
                {
                    aux2 = numero1 * numero2;
                    break;
                }
                case "/":
                {
                    if (numero2.getNumero () == 0)
                    {
                        aux2 = 0;
                    }
                    else
                    {
                        aux2 = numero1 / numero2;
                    }
                    break;
                }


            }
            return aux2;
        }

      

        /// <summary>
        /// valida que el operador sea un caracter valido
        /// </summary>
        /// <param name="operador">operador a validar</param>
        /// <returns>retorna un operador valido o "+" si no es valido</returns>
        public static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "+";
            }

 
        }
    }
}
