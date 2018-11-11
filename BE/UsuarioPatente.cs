namespace BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UsuarioPatente
    {
        public Guid IdPatente { get; set; }
        public Guid IdUsuario { get; set; }
        public bool Negada { get; set; }
        //Agregar campo para Digito verificador
    }
}
