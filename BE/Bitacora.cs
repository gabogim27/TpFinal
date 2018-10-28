namespace BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlTypes;

    public class Bitacora
    {
        public Guid IdLog { get; set; }

        public SqlDateTime Fecha { get; set; }

        public string Criticidad { get; set; }

        public string Actividad { get; set; }

        public string InformacionAsociada { get; set; }

        public int IdUsuario { get; set; }

        public int DVH { get; set; }
    }
}
