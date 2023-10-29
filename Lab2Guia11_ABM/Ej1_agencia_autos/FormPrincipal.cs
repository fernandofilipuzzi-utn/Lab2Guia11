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
    public partial class FormPrincipal : Form
    {
        Vehiculo[] vehiculos = new Vehiculo[100];
        int idx=0;

        public FormPrincipal()
        {
            InitializeComponent();

            Init_formularios();


            /*comentar en producción*/
            test();
        }

        /*harcoding para probar*/
        void test()
        {
            /*primer caso*/
            Vehiculo v = new Vehiculo();
            v.Marca = "Renault";
            v.Modelo = "R4";
            v.Año = 1983;
            v.Motor = "Ventoux";
            v.Combustible = "Nafta";
            v.Color = "Blanco";
            v.Km = 1000;
            v.Precio = 1000;
            v.Contacto = "fernando";
            vehiculos[idx] = v;
            idx++;
            Imprimir(v);

            /*segundo caso*/
            v = new Vehiculo();
            v.Marca = "Renault";
            v.Modelo = "R12";
            v.Año = 1990;
            v.Motor = "Berline";
            v.Combustible = "Nafta";
            v.Color = "Rojo";
            v.Km = 1000;
            v.Precio = 1000;
            v.Contacto = "fernando";
            vehiculos[idx++] = v;
            Imprimir(v);

            /*tercer caso*/
            v = new Vehiculo();
            v.Marca = "Renault";
            v.Modelo = "R19";
            v.Año = 1994;
            v.Motor = "Energy";
            v.Combustible = "Nafta";
            v.Color = "Gris";
            v.Km = 1000;
            v.Precio = 1000;
            v.Contacto = "fernando";
            vehiculos[idx++] = v;
            Imprimir(v);

            /*cuarto caso*/
            v = new Vehiculo();
            v.Marca = "Volkswagen";
            v.Modelo = "Gold Trends";
            v.Año = 2015;
            v.Motor = "Motor";
            v.Combustible = "Nafta";
            v.Color = "Gris";
            v.Km = 1000;
            v.Precio = 1000;
            v.Contacto = "fernando";
            vehiculos[idx++] = v;
            Imprimir(v);

            /*quinto caso caso*/
            v = new Vehiculo();
            v.Marca = "Renault";
            v.Modelo = "Megane";
            v.Año = 2015;
            v.Motor = "L4 8V";
            v.Combustible = "Diesel";
            v.Color = "Blanco";
            v.Km = 1000;
            v.Precio = 1000;
            v.Contacto = "fernando";
            vehiculos[idx++] = v;
            Imprimir(v);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormEdicion ed = new FormEdicion();
            ed.Limpiar();

            bool estado=true;

            while(estado==true)
            {
                if (ed.ShowDialog() == DialogResult.OK)
                {
                    //evaluar los campos
                    int año;
                    bool result1 = int.TryParse(ed.textBox3.Text, out año);
                    if (result1 != true)
                    {
                        ed.errorProvider1.SetError(ed.textBox3, "Error, debe ser un número entero");
                    }

                    double precio = 0;
                    bool result2 = double.TryParse(ed.textBox8.Text, out precio);
                    if (result2 != true)
                    {
                        ed.errorProvider1.SetError(ed.textBox8, "Error, debe ser un número. (separador decimal es coma)");
                    }

                    //

                    if (result1 == true && result2 == true)
                    {
                        Vehiculo v = new Vehiculo();
                        v.Marca = ed.textBox1.Text;
                        v.Modelo = ed.textBox2.Text;
                        v.Año = año;
                        v.Motor = ed.textBox4.Text;
                        v.Combustible = ed.textBox5.Text;
                        v.Color = ed.textBox6.Text;
                        v.Km = Convert.ToDouble(ed.textBox7.Text);
                        v.Precio = precio;
                        v.Contacto = ed.textBox9.Text;

                        //agrego 
                        vehiculos[idx++] = v;
                        Imprimir(v);

                        estado = false;
                    }
                }
                else 
                {
                    estado = false;
                }
            }
            ed.Dispose();
        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selecciono el registro de la lista
            int sel = listBox1.SelectedIndex;

            if (sel > 0 && sel < idx)
            {
                Vehiculo v = vehiculos[sel];

                FormEdicion ed = new FormEdicion();

                ed.textBox1.Text = v.Marca;
                ed.textBox2.Text = v.Modelo;
                ed.textBox3.Text = v.Año.ToString("0000");
                ed.textBox4.Text = v.Motor;
                ed.textBox5.Text = v.Combustible;
                ed.textBox6.Text = v.Color;
                ed.textBox7.Text = v.Km.ToString("F2");
                ed.textBox8.Text = v.Precio.ToString("F2");
                ed.textBox9.Text = v.Contacto;

                if (ed.ShowDialog() == DialogResult.OK)
                {
                    //evaluar los campos
                    int año;
                    bool result1 = int.TryParse(ed.textBox3.Text, out año);
                    if (result1 != true)
                    {
                        ed.errorProvider1.SetError(ed.textBox3, "Error, debe ser un número entero");
                    }

                    double precio = 0;
                    bool result2 = double.TryParse(ed.textBox8.Text, out precio);
                    if (result2 != true)
                    {
                        ed.errorProvider1.SetError(ed.textBox8, "Error, debe ser un número. (separador decimal es coma)");
                    }

                    //

                    if (result1 == true && result2 == true)
                    {
                        v.Marca = ed.textBox1.Text;
                        v.Modelo = ed.textBox2.Text;
                        v.Año = año;
                        v.Motor = ed.textBox4.Text;
                        v.Combustible = ed.textBox5.Text;
                        v.Color = ed.textBox6.Text;
                        v.Km = Convert.ToDouble(ed.textBox7.Text);
                        v.Precio = precio;
                        v.Contacto = ed.textBox9.Text;

                        Imprimir(v, sel);
                    }
                }
            }
        }

        /*manejador del filtrado */
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string marca = textBox1.Text.Trim();

            int año = -1;
            if (textBox2.Text.Trim() != "")
            {
                año = Convert.ToInt32(textBox2.Text);
            }
                       

            for (int i = 0; i < idx; i++)
            {
                if ( (año==-1 || año==vehiculos[i].Año)
                    &&
                    (marca=="" || marca == vehiculos[i].Marca))
                {
                    Imprimir(vehiculos[i]);
                }
            }
        }

        /**/
        //forma alternativa para trabajar con ventanas modales.
        //     |
        //     v

        FormEdicion ed1;

        private void Init_formularios()
        {
            //Init_formularios() llamar desde el constructor de este formulario
            //ver codigo al principio de esta clase.

            ed1 = new FormEdicion();
            ed1.button3.Click += new System.EventHandler(this.FormEdicio_button3_Click);
        }
                
        private void button3_Click(object sender, EventArgs e)
        {

            ed1.Limpiar();
            ed1.ShowDialog();
        }
        
        //este manejador lo cree yo, copiando uno parecido 
        //y lo uso para atentende el aceptar del formulario secundario.
        private void FormEdicio_button3_Click(object sender, EventArgs e)
        {
            //evaluar los campos
            int año;
            bool result1 = int.TryParse(ed1.textBox3.Text, out año);
            if (result1 != true)
            {
                ed1.errorProvider1.SetError(ed1.textBox3, "Error, debe ser un número entero");
            }

            double precio = 0;
            bool result2 = double.TryParse(ed1.textBox8.Text, out precio);
            if (result2 != true)
            {
                ed1.errorProvider1.SetError(ed1.textBox8, "Error, debe ser un número. (separador decimal es coma)");
            }

            //

            if (result1 == true && result2 == true)
            {
                Vehiculo v = new Vehiculo();
                v.Marca = ed1.textBox1.Text;
                v.Modelo = ed1.textBox2.Text;
                v.Año = año;
                v.Motor = ed1.textBox4.Text;
                v.Combustible = ed1.textBox5.Text;
                v.Color = ed1.textBox6.Text;
                v.Km = Convert.ToDouble(ed1.textBox7.Text);
                v.Precio = precio;
                v.Contacto = ed1.textBox9.Text;

                //agrego 
                vehiculos[idx++] = v;
                Imprimir(v);

                ed1.DialogResult = DialogResult.OK;
            }
        }

        //-----------------


        /*uteleria para imprimir*/
        private void Imprimir(Vehiculo v)
        {
            listBox1.Items.Add("");
            Imprimir(v, listBox1.Items.Count - 1);
        }

        private void Imprimir(Vehiculo v, int i)
        {
            string linea = String.Format("{0,-15}{1,-15}{2,-10}{3,-10}{4,-10}{5,-10}{6,-15:f2}{7,-15:f2}{8,-20}",
                                v.Marca, v.Modelo, v.Año, v.Motor, v.Combustible, v.Color, v.Km, v.Precio,
                                v.Contacto);

            Console.WriteLine(linea);

            listBox1.Items[i] = linea;
            listBox1.SelectedIndex = -1;
        }
    }
}
