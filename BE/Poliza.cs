namespace BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Poliza
    {
        public Guid IdPoliza { get; set; }
        public DetallePoliza Detalle { get; set; }
        public Guid IdCliente { get; set; }//CAMBIARLO AL OBJETO
        public bool Estado { get; set; }
        public int NroPoliza { get; set; }
    }
}
