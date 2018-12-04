namespace BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DetallePoliza
    {
        public Guid IdDetalle { get; set; }
        public List<Cobertura> Coberturas { get; set; }
        public Guid IdVehiculo { get; set; }//CAMBIARLO A LISTA, PUEDE TENER UNO O MAS VEHICULOS ASEGURADOS
        public decimal Prima { get; set; }
        public decimal SumaAsegurada { get; set; }
        public int DVH { get; set; }
    }
}
