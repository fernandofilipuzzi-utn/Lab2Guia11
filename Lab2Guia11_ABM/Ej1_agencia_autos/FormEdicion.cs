using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ejemplo_agencia_autos
{
    public partial class FormEdicion : Form
    {
      
        public FormEdicion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void FormEdicion_Load(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {
            /*
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
             * */
           
            
            textBox1.Text = "Renault";
            textBox2.Text = "R4";
            textBox3.Text = "1983";
            textBox4.Text = "Ventoux";
            textBox5.Text = "Nafta";
            textBox6.Text = "Blanco";
            textBox7.Text = "1000";
            textBox8.Text = "1000";
            textBox9.Text = "fernando";
         
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
