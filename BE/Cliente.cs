using System;

namespace BE
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public Domicilio Domicilio { get; set; }
        public Contacto Contacto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Dni { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
    }
}
