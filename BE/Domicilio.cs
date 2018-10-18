using System;

namespace BE
{
    public class Domicilio
    {
        public Guid IdDomicilio { get; set; }
        public string Direccion { get; set; }
        public Localidad Localidad { get; set; }
        public string CodPostal { get; set; }
    }
}