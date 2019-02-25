﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class frmPrincipal : Form, IPrincipal
    {
        private readonly IABMUsuarios abmUsuarios;
        private ISessionInfo SessionInfo;
        private IBitacora Bitacora;
        private IRealizarCopiaSeguridad RealizarCopiaDeSeguridad;
        private IRestaurarCopiaDeSeguridad RestaurarCopiaDeSeguridad;
        private IABMFamilia ABMFamilia;
        private ICambiarIdioma CambiarIdioma;
        private ICambiarContraseña CambiarContraseña;
        private IPolizaWizard PolizaWizard;
        private IDetallePoliza DetallePoliza;
        private IDetalleCliente DetalleCliente;
        public IDetalleVehiculo DetalleVehiculo;


        public frmPrincipal(IABMUsuarios abmUsuarios, ISessionInfo SessionInfo,
            IBitacora Bitacora, IRealizarCopiaSeguridad RealizarCopiaDeSeguridad,
            IRestaurarCopiaDeSeguridad RestaurarCopiaDeSeguridad, IABMFamilia ABMFamilia,
            ICambiarIdioma CambiarIdioma, ICambiarContraseña CambiarContraseña,
            IPolizaWizard PolizaWizard, IDetallePoliza DetallePoliza, IDetalleCliente DetalleCliente,
            IDetalleVehiculo DetalleVehiculo)
        {
            this.SessionInfo = SessionInfo;
            this.ABMFamilia = ABMFamilia;
            this.Bitacora = Bitacora;
            this.RealizarCopiaDeSeguridad = RealizarCopiaDeSeguridad;
            this.RestaurarCopiaDeSeguridad = RestaurarCopiaDeSeguridad;
            this.abmUsuarios = abmUsuarios;
            this.CambiarIdioma = CambiarIdioma;
            this.CambiarContraseña = CambiarContraseña;
            this.PolizaWizard = PolizaWizard;
            this.DetallePoliza = DetallePoliza;
            this.DetalleCliente = DetalleCliente;
            this.DetalleVehiculo = DetalleVehiculo;
            InitializeComponent();
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //var patForm = SessionInfo.ObtenerPermisosFormularios();

            //var patUsu = SessionInfo.ObtenerPermisosUsuario();

            //////patentesUsu.Where(item => patentesForm.Select(item2 => item2.IdPatente).Contains(item.IdPatente)).ToList();

            //if (!patForm.Exists(item => patUsu.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente)))
            //{
            //    tlsAdministrarUsuario.Enabled = false;
            //}

        }

        private void Usuarios_Click(object sender, EventArgs e)
        {

            abmUsuarios.MdiParent = this;
            abmUsuarios.Show();
        }

        private void RealizarCopiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizarCopiaDeSeguridad.MdiParent = this;
            RealizarCopiaDeSeguridad.Show();
        }

        private void RestaurarCopiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestaurarCopiaDeSeguridad.MdiParent = this;
            RestaurarCopiaDeSeguridad.Show();
        }

        private void VisualizarBitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitacora.MdiParent = this;
            Bitacora.Show();
        }

        private void administrarFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMFamilia.MdiParent = this;
            ABMFamilia.Show();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Esta seguro que desea salir del sistema?", "Salir del sistema", MessageBoxButtons.YesNo);
            if (confirmation == DialogResult.Yes)
            {
                Application.Exit();
            }

            return;
        }

        private void CambiarIdiomaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CambiarIdioma.MdiParent = this;
            CambiarIdioma.Show();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarContraseña.MdiParent = this;
            CambiarContraseña.Show();
        }

        private void EmisiónDePólizasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PolizaWizard.MdiParent = this;
            PolizaWizard.Show();
        }

        private void BuscarPólizaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetallePoliza.MdiParent = this;
            DetallePoliza.Show();
        }

        private void VerClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetalleCliente.MdiParent = this;
            DetalleCliente.Show();
        }

        private void VerVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetalleVehiculo.MdiParent = this;
            DetalleVehiculo.Show();
        }
    }
}
