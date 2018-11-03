namespace BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TraduccionControles : Formulario
    {
        public Guid IdTraduccion { get; set; }
        public string Traduccion { get; set; }
        public IdiomaUsuario Idioma { get; set; }
        public string ControlName { get; set; }
        public string MensajeCodigo { get; set; }
    }
}
