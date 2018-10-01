using System;

namespace BE
{
    public class Localidad
    {
        public Guid IdLocalidad { get; set; }
        public string Descripcion { get; set; }
        public Provincia Provincia { get; set; }
    }
}