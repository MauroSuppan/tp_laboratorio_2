using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clase5TP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
        }
        
        private void btnOperar_Click(object sender, EventArgs e)
        {
            //se crean 2 objetos de tipo numero
            Numero num1 = new Numero(this.txtNumero1.Text.ToString());
            Numero num2 = new Numero(this.txtNumero2.Text.ToString());

            this.lblResultado.Visible = true;
            //realiza el metodo operar y lo que retorna lo conviente en string y lo guarda en lblresultado            
            this.lblResultado.Text = (Calculadora.Operar(num1, num2, cmbOperacion.Text)).ToString(); 
            
        }

        //el boton llama al metodo Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        //el metodo borra el contenido de los textbox, carga "" en combobox, y le saca la visibilidad a lblResultado
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperacion.Text = "";
            this.lblResultado.Visible = false;

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
