namespace BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cobertura
    {
        public Guid IdCobertura { get; set; }
        public bool Seleccionada { get; set; }
        public string Descripcion { get; set; }
        public decimal PrimaAsegurada { get; set; }
    }
}
