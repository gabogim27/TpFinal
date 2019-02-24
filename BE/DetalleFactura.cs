namespace BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DetalleFactura
    {
        public Guid IdDetalle { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Importe { get; set; }
        public int DVH { get; set; }
    }
}
