namespace SSTIS
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionPólizasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmisiónDePólizasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuscarPólizaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionFacturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerDetalleFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionVehiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AyudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsAdministrarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarFamiliaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RealizarCopiaDeSeguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestaurarCopiaDeSeguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VisualizarBitácoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AyudaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CambiarIdiomaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AccionesToolStripMenuItem,
            this.AyudaToolStripMenuItem,
            this.SeguridadToolStripMenuItem,
            this.AyudaToolStripMenuItem1,
            this.CerrarSesiónToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(955, 24);
            this.MenuStrip1.TabIndex = 27;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // AccionesToolStripMenuItem
            // 
            this.AccionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GestionPólizasToolStripMenuItem,
            this.GestionClientesToolStripMenuItem,
            this.GestionFacturasToolStripMenuItem,
            this.GestionVehiculosToolStripMenuItem});
            this.AccionesToolStripMenuItem.Name = "AccionesToolStripMenuItem";
            this.AccionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.AccionesToolStripMenuItem.Text = "Acciones";
            // 
            // GestionPólizasToolStripMenuItem
            // 
            this.GestionPólizasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EmisiónDePólizasToolStripMenuItem,
            this.BuscarPólizaToolStripMenuItem});
            this.GestionPólizasToolStripMenuItem.Name = "GestionPólizasToolStripMenuItem";
            this.GestionPólizasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.GestionPólizasToolStripMenuItem.Text = "Gestion Pólizas";
            // 
            // EmisiónDePólizasToolStripMenuItem
            // 
            this.EmisiónDePólizasToolStripMenuItem.Name = "EmisiónDePólizasToolStripMenuItem";
            this.EmisiónDePólizasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.EmisiónDePólizasToolStripMenuItem.Text = "Emisión de Pólizas";
            this.EmisiónDePólizasToolStripMenuItem.Click += new System.EventHandler(this.EmisiónDePólizasToolStripMenuItem_Click);
            // 
            // BuscarPólizaToolStripMenuItem
            // 
            this.BuscarPólizaToolStripMenuItem.Name = "BuscarPólizaToolStripMenuItem";
            this.BuscarPólizaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.BuscarPólizaToolStripMenuItem.Text = "Ver Pólizas";
            this.BuscarPólizaToolStripMenuItem.Click += new System.EventHandler(this.BuscarPólizaToolStripMenuItem_Click);
            // 
            // GestionClientesToolStripMenuItem
            // 
            this.GestionClientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerClientesToolStripMenuItem});
            this.GestionClientesToolStripMenuItem.Name = "GestionClientesToolStripMenuItem";
            this.GestionClientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.GestionClientesToolStripMenuItem.Text = "Gestion Clientes";
            // 
            // VerClientesToolStripMenuItem
            // 
            this.VerClientesToolStripMenuItem.Name = "VerClientesToolStripMenuItem";
            this.VerClientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.VerClientesToolStripMenuItem.Text = "Ver Datos Cliente";
            this.VerClientesToolStripMenuItem.Click += new System.EventHandler(this.VerClientesToolStripMenuItem_Click);
            // 
            // GestionFacturasToolStripMenuItem
            // 
            this.GestionFacturasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerDetalleFacturaToolStripMenuItem});
            this.GestionFacturasToolStripMenuItem.Name = "GestionFacturasToolStripMenuItem";
            this.GestionFacturasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.GestionFacturasToolStripMenuItem.Text = "Gestion Facturas";
            // 
            // VerDetalleFacturaToolStripMenuItem
            // 
            this.VerDetalleFacturaToolStripMenuItem.Name = "VerDetalleFacturaToolStripMenuItem";
            this.VerDetalleFacturaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.VerDetalleFacturaToolStripMenuItem.Text = "Ver Detalle Factura";
            // 
            // GestionVehiculosToolStripMenuItem
            // 
            this.GestionVehiculosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerVehiculoToolStripMenuItem});
            this.GestionVehiculosToolStripMenuItem.Name = "GestionVehiculosToolStripMenuItem";
            this.GestionVehiculosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.GestionVehiculosToolStripMenuItem.Text = "Gestion Vehiculos";
            // 
            // VerVehiculoToolStripMenuItem
            // 
            this.VerVehiculoToolStripMenuItem.Name = "VerVehiculoToolStripMenuItem";
            this.VerVehiculoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.VerVehiculoToolStripMenuItem.Text = "Ver Datos Vehiculo";
            this.VerVehiculoToolStripMenuItem.Click += new System.EventHandler(this.VerVehiculoToolStripMenuItem_Click);
            // 
            // AyudaToolStripMenuItem
            // 
            this.AyudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsAdministrarUsuario,
            this.administrarFamiliaToolStripMenuItem});
            this.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem";
            this.AyudaToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.AyudaToolStripMenuItem.Text = "Administración";
            // 
            // tlsAdministrarUsuario
            // 
            this.tlsAdministrarUsuario.Name = "tlsAdministrarUsuario";
            this.tlsAdministrarUsuario.Size = new System.Drawing.Size(179, 22);
            this.tlsAdministrarUsuario.Text = "Administrar Usuario";
            this.tlsAdministrarUsuario.Click += new System.EventHandler(this.Usuarios_Click);
            // 
            // administrarFamiliaToolStripMenuItem
            // 
            this.administrarFamiliaToolStripMenuItem.Name = "administrarFamiliaToolStripMenuItem";
            this.administrarFamiliaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.administrarFamiliaToolStripMenuItem.Text = "Administrar Familia";
            this.administrarFamiliaToolStripMenuItem.Click += new System.EventHandler(this.administrarFamiliaToolStripMenuItem_Click);
            // 
            // SeguridadToolStripMenuItem
            // 
            this.SeguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RealizarCopiaDeSeguridadToolStripMenuItem,
            this.RestaurarCopiaDeSeguridadToolStripMenuItem,
            this.VisualizarBitácoraToolStripMenuItem});
            this.SeguridadToolStripMenuItem.Name = "SeguridadToolStripMenuItem";
            this.SeguridadToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.SeguridadToolStripMenuItem.Text = "Seguridad";
            // 
            // RealizarCopiaDeSeguridadToolStripMenuItem
            // 
            this.RealizarCopiaDeSeguridadToolStripMenuItem.Name = "RealizarCopiaDeSeguridadToolStripMenuItem";
            this.RealizarCopiaDeSeguridadToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.RealizarCopiaDeSeguridadToolStripMenuItem.Text = "Realizar Copia de Seguridad";
            this.RealizarCopiaDeSeguridadToolStripMenuItem.Click += new System.EventHandler(this.RealizarCopiaDeSeguridadToolStripMenuItem_Click);
            // 
            // RestaurarCopiaDeSeguridadToolStripMenuItem
            // 
            this.RestaurarCopiaDeSeguridadToolStripMenuItem.Name = "RestaurarCopiaDeSeguridadToolStripMenuItem";
            this.RestaurarCopiaDeSeguridadToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.RestaurarCopiaDeSeguridadToolStripMenuItem.Text = "Restaurar Copia de Seguridad";
            this.RestaurarCopiaDeSeguridadToolStripMenuItem.Click += new System.EventHandler(this.RestaurarCopiaDeSeguridadToolStripMenuItem_Click);
            // 
            // VisualizarBitácoraToolStripMenuItem
            // 
            this.VisualizarBitácoraToolStripMenuItem.Name = "VisualizarBitácoraToolStripMenuItem";
            this.VisualizarBitácoraToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.VisualizarBitácoraToolStripMenuItem.Text = "Visualizar Bitácora";
            this.VisualizarBitácoraToolStripMenuItem.Click += new System.EventHandler(this.VisualizarBitácoraToolStripMenuItem_Click);
            // 
            // AyudaToolStripMenuItem1
            // 
            this.AyudaToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CambiarIdiomaToolStripMenuItem1,
            this.cambiarContraseñaToolStripMenuItem});
            this.AyudaToolStripMenuItem1.Name = "AyudaToolStripMenuItem1";
            this.AyudaToolStripMenuItem1.Size = new System.Drawing.Size(53, 20);
            this.AyudaToolStripMenuItem1.Text = "Ayuda";
            // 
            // CambiarIdiomaToolStripMenuItem1
            // 
            this.CambiarIdiomaToolStripMenuItem1.Name = "CambiarIdiomaToolStripMenuItem1";
            this.CambiarIdiomaToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.CambiarIdiomaToolStripMenuItem1.Text = "Cambiar Idioma";
            this.CambiarIdiomaToolStripMenuItem1.Click += new System.EventHandler(this.CambiarIdiomaToolStripMenuItem1_Click);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar Contraseña";
            this.cambiarContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambiarContraseñaToolStripMenuItem_Click);
            // 
            // CerrarSesiónToolStripMenuItem
            // 
            this.CerrarSesiónToolStripMenuItem.Name = "CerrarSesiónToolStripMenuItem";
            this.CerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.CerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.CerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.CerrarSesiónToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 567);
            this.Controls.Add(this.MenuStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem AccionesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem GestionPólizasToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EmisiónDePólizasToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem BuscarPólizaToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem GestionClientesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem VerClientesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem GestionFacturasToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem VerDetalleFacturaToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem GestionVehiculosToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem VerVehiculoToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AyudaToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tlsAdministrarUsuario;
        internal System.Windows.Forms.ToolStripMenuItem SeguridadToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem RealizarCopiaDeSeguridadToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem RestaurarCopiaDeSeguridadToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem VisualizarBitácoraToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AyudaToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem CambiarIdiomaToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem CerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarFamiliaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
    }
}