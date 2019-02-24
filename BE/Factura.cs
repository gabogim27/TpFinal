namespace BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Factura
    {
        public Guid IdFactura { get; set; }
        public int NumeroFactura { get; set; }
        public bool Estado { get; set; }
        public bool Paga { get; set; }
        public DateTime Vencimiento { get; set; }
        public Poliza Poliza { get; set; }
        public int NumeroCuota { get; set; }
        public DetalleFactura DetalleFactura { get; set; }
    }
}
