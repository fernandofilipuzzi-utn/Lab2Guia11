using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejemplo_servicio_autos
{
    class Servicio
    {
        public enum TipoServicio { Nafta_Nac, Nafta_Imp, Diesel_Nac, Diesel_Imp };

        public double UdAceite { get; set; }
        public double UdPrecio { get; set; }
                
        public string Vehiculo { get; set; }
        public int Filtro { get; set; }
        public TipoServicio Tipo { get; set; }

        public int Servicios { get; set; }
        public double TotalLitros { get; set; }
        public double TotalPrecio {get;set;}

        public Servicio(string Vehiculo, int Filtro, TipoServicio ts, double udAceite, double udPrecio) 
        {
            this.Vehiculo = Vehiculo;
            this.Filtro = Filtro;
            this.Tipo = ts;
            this.UdAceite=udAceite;
            this.UdPrecio = udPrecio;
        }

        public void Realizar()
        {
            Servicios++;
            TotalLitros += UdAceite;
            TotalPrecio += UdPrecio;
        }
    }
}
