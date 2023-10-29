using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Ejemplo_servicio_autos
{
    public partial class FormPrincipal : Form
    {

        List<Servicio> servicios = new List<Servicio>();
        //ArrayList servicios = new ArrayList();
       
        Servicio seleccionado;
        


        public FormPrincipal()
        {
            InitializeComponent();

            button1.Enabled = false;

            //preinicialización
            init();
        }

        public void init()
        {
            servicios.Add(new Servicio("Kangoo", 1001,
                            Servicio.TipoServicio.Nafta_Nac, 4.7, 542));
            servicios.Add(new Servicio("Focus", 2001,
                            Servicio.TipoServicio.Nafta_Imp, 4, 650));
            servicios.Add(new Servicio("Genérico Diesel", 2015,
                            Servicio.TipoServicio.Diesel_Nac, 4.5, 610));
            servicios.Add(new Servicio("EcoSport Diesel", 1001,
                            Servicio.TipoServicio.Diesel_Imp, 4.2, 720));
            servicios.Add(new Servicio("Genérico Nafta", 1015,
                            Servicio.TipoServicio.Nafta_Nac, 4, 486));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                seleccionado.Realizar();
                
                FormTicket showTicket = new FormTicket();
                showTicket.listBox1.Items.Add(" Tipo de Servicio: " + seleccionado.Tipo.ToString());
                showTicket.listBox1.Items.Add(" Preciio total: " + seleccionado.UdPrecio.ToString("0.00"));
                showTicket.ShowDialog();
                showTicket.Dispose();

                seleccionado = null;
                comboBox2.SelectedIndex = -1;
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            double recaudacion = 0d; ;

            string linea = "";
            foreach (Servicio s in servicios)
            {
                linea = String.Format("{0,-16}{1,-5}{2,-5}{3,-10}{4,6:f2}{5,10:f2}",
                                        s.Vehiculo, s.Servicios,s.Filtro,s.Tipo, 
                                        s.TotalLitros,
                                        s.TotalPrecio);

                listBox1.Items.Add(linea);

                recaudacion += s.TotalPrecio;
            }
            listBox1.Items.Add("----------------------------------------------");
            linea = String.Format("{0,-16}{1,-5}{2,-5}{3,-10}{4,6:f2}{5,10:f2}",
                                        "", "", "", "", "",
                                        recaudacion);
            listBox1.Items.Add(linea);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //por vehiculos
            //ver items del combobox2  en el editor de propiedades
            if (comboBox2.SelectedIndex != -1)
            {
                seleccionado = (Servicio)servicios[comboBox2.SelectedIndex];
                button1.Enabled = true;
            }
            else
            {
                seleccionado = null;
            }
            comboBox3.SelectedIndex = comboBox2.SelectedIndex;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //por codigos de filtros filtro/codigo - 
            //ver items del combobox3  en el editor de propiedades
            if (comboBox3.SelectedIndex != -1)
            {
                seleccionado = (Servicio)servicios[comboBox3.SelectedIndex];
               button1.Enabled = true;
            }
            else
            {
                seleccionado = null;
            }
            comboBox2.SelectedIndex = comboBox3.SelectedIndex;
        }
    }
}
