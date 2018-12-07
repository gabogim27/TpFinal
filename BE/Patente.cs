namespace BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Patente
    {
        public Guid IdPatente { get; set; }
        public string Descripcion { get; set; }
        public bool Negada { get; set; }
    }
}
