namespace BE
{
    public class Usuario 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int CantIngresosFallidos { get; set; }
        public bool Estado { get; set; }
        public int PrimerLogin { get; set; }
        public int IdIdioma { get; set; }
        public string UsuarioEncriptado { get; set; }
        public Domicilio Domicilio { get; set; }
        public Contacto Contacto { get; set; }
    }
}
