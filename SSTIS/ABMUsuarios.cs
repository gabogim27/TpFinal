using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Interfaces;
using DAL.Interfaces;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class ABMUsuarios : Form, IABMUsuarios
    {
        public IServicio<Usuario> ServicioUsuario { get; set; }
        public INuevoUsuario nuevoUsuario { get; set; }

        public ABMUsuarios(IServicio<Usuario> servicioUsuario, INuevoUsuario nuevoUsuario)
        {
            InitializeComponent();
            this.ServicioUsuario = servicioUsuario;
            this.nuevoUsuario = nuevoUsuario;
        }

        //public ABMUsuarios(IRepository<Usuario> repository)
        //{
        //    InitializeComponent();
        //    this.Repository = repository;
        //}

        //public IRepository<Usuario> Repository { get; set; }

        //public ABMUsuarios()
        //{
        //    InitializeComponent();
        //}

        //public Usuario Usuario {
        //    get
        //    {
        //        var usuario = new Usuario();

        //        return usuario;
        //    }
        //    set
        //    {

        //    };
        //} 

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            nuevoUsuario.Show();
        }        

        private void ABMUsuarios_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {
            //Retrieve provincias
            var provincias = BLL.ProvinciaBLL.Getinstancia().Retrive();
            cboProvincia.DataSource = provincias; 
            cboProvincia.DisplayMember = "Descripcion";
            cboProvincia.ValueMember = "IdProvincia";
            //Retrieve Localidades
            var localidades = BLL.LocalidadBLL.Getinstancia().Retrive();
            cboLocalidad.DataSource = localidades;
            cboLocalidad.DisplayMember = "Descripcion";
            cboLocalidad.ValueMember = "IdLocalidad";
        }
    }
}
