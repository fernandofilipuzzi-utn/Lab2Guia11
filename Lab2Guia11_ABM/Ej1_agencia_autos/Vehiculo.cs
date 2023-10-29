using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejemplo_agencia_autos
{
    class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public string Motor { get; set; }
        public string Combustible { get; set; }
        public string Color { get; set; }
        public double Km { get; set; }
        public double Precio { get; set; }
        public string Contacto { get; set; }

        public Vehiculo() 
        {
        }
    }
}
