namespace BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Vehiculo
    {
        public Guid IdVehiculo { get; set; }
        public TipoUso _TipoUso { get; set; }
        public TipoVehiculo _TipoVehiculo { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
        public int CantPuertas { get; set; }
        public string Color { get; set; }
        public string Combustible { get; set; }
        public string NumChasis { get; set; }
        public string NumSerie { get; set; }
        public string Patente { get; set; }
        public string Año { get; set; }
    }
}
