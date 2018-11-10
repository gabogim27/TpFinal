﻿using System;
using System.Collections.Generic;

namespace BE
{
    public class Usuario 
    {
        public Guid IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int CantIngresosFallidos { get; set; }
        public bool Estado { get; set; }
        public bool PrimerLogin { get; set; }
        public string Sexo { get; set; }
        public Guid IdIdioma { get; set; }
        public Domicilio Domicilio { get; set; }
        public Contacto Contacto { get; set; }
        public string ContraseñaEncriptada { get; set; }

        public List<Familia> Familia { get; set; }

        public List<Patente> Patentes { get; set; }
    }
}
