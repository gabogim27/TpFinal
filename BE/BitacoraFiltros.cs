namespace BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BitacoraFiltros
    {
        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public List<string> IdsUsuarios { get; set; }

        public List<string> Criticidades { get; set; }
    }
}
