namespace SSTIS
{
    partial class DetallePoliza
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
            this.Label2 = new System.Windows.Forms.Label();
            this.Asegurado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tasaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numPolizaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Prima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.AyudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerDetalleFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionFacturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuscarPólizaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmisiónDePólizasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionPólizasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionVehiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EdicionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(763, 89);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(114, 13);
            this.Label2.TabIndex = 28;
            this.Label2.Text = "DETALLE DE POLIZA";
            // 
            // Asegurado
            // 
            this.Asegurado.HeaderText = "Prima";
            this.Asegurado.Name = "Asegurado";
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            // 
            // primaColumna
            // 
            this.primaColumna.HeaderText = "Encargado de la aprobación";
            this.primaColumna.Name = "primaColumna";
            // 
            // tasaColumna
            // 
            this.tasaColumna.HeaderText = "Encargado de la emision";
            this.tasaColumna.Name = "tasaColumna";
            // 
            // sumaColumna
            // 
            this.sumaColumna.HeaderText = "Estado";
            this.sumaColumna.Name = "sumaColumna";
            // 
            // numPolizaColumna
            // 
            this.numPolizaColumna.HeaderText = "N° Póliza";
            this.numPolizaColumna.Name = "numPolizaColumna";
            // 
            // selColumna
            // 
            this.selColumna.HeaderText = "Fecha de Emision";
            this.selColumna.Name = "selColumna";
            // 
            // TextBox1
            // 
            this.TextBox1.Enabled = false;
            this.TextBox1.Location = new System.Drawing.Point(354, 353);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(195, 20);
            this.TextBox1.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(267, 360);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Prima total:";
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selColumna,
            this.numPolizaColumna,
            this.sumaColumna,
            this.tasaColumna,
            this.primaColumna,
            this.Cliente,
            this.Asegurado,
            this.Prima});
            this.DataGridView1.Location = new System.Drawing.Point(0, 28);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(873, 150);
            this.DataGridView1.TabIndex = 0;
            // 
            // Prima
            // 
            this.Prima.HeaderText = "Monto asegurado";
            this.Prima.Name = "Prima";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.TextBox1);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.DataGridView1);
            this.GroupBox1.Location = new System.Drawing.Point(3, 54);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(873, 379);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Detalle Póliza";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Location = new System.Drawing.Point(0, 105);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(879, 400);
            this.Panel1.TabIndex = 31;
            // 
            // AyudaToolStripMenuItem
            // 
            this.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem";
            this.AyudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.AyudaToolStripMenuItem.Text = "Ayuda";
            // 
            // VerVehiculoToolStripMenuItem
            // 
            this.VerVehiculoToolStripMenuItem.Name = "VerVehiculoToolStripMenuItem";
            this.VerVehiculoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.VerVehiculoToolStripMenuItem.Text = "Ver Datos Vehiculo";
            // 
            // VerDetalleFacturaToolStripMenuItem
            // 
            this.VerDetalleFacturaToolStripMenuItem.Name = "VerDetalleFacturaToolStripMenuItem";
            this.VerDetalleFacturaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.VerDetalleFacturaToolStripMenuItem.Text = "Ver Detalle Factura";
            // 
            // GestionFacturasToolStripMenuItem
            // 
            this.GestionFacturasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerDetalleFacturaToolStripMenuItem});
            this.GestionFacturasToolStripMenuItem.Name = "GestionFacturasToolStripMenuItem";
            this.GestionFacturasToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.GestionFacturasToolStripMenuItem.Text = "Gestion Facturas";
            // 
            // VerClientesToolStripMenuItem
            // 
            this.VerClientesToolStripMenuItem.Name = "VerClientesToolStripMenuItem";
            this.VerClientesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.VerClientesToolStripMenuItem.Text = "Ver Datos Cliente";
            // 
            // GestionClientesToolStripMenuItem
            // 
            this.GestionClientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerClientesToolStripMenuItem});
            this.GestionClientesToolStripMenuItem.Name = "GestionClientesToolStripMenuItem";
            this.GestionClientesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.GestionClientesToolStripMenuItem.Text = "Gestion Clientes";
            // 
            // BuscarPólizaToolStripMenuItem
            // 
            this.BuscarPólizaToolStripMenuItem.Name = "BuscarPólizaToolStripMenuItem";
            this.BuscarPólizaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.BuscarPólizaToolStripMenuItem.Text = "Ver Pólizas";
            // 
            // EmisiónDePólizasToolStripMenuItem
            // 
            this.EmisiónDePólizasToolStripMenuItem.Name = "EmisiónDePólizasToolStripMenuItem";
            this.EmisiónDePólizasToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.EmisiónDePólizasToolStripMenuItem.Text = "Emisión de Pólizas";
            // 
            // GestionPólizasToolStripMenuItem
            // 
            this.GestionPólizasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EmisiónDePólizasToolStripMenuItem,
            this.BuscarPólizaToolStripMenuItem});
            this.GestionPólizasToolStripMenuItem.Name = "GestionPólizasToolStripMenuItem";
            this.GestionPólizasToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.GestionPólizasToolStripMenuItem.Text = "Gestion Pólizas";
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
            // GestionVehiculosToolStripMenuItem
            // 
            this.GestionVehiculosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerVehiculoToolStripMenuItem});
            this.GestionVehiculosToolStripMenuItem.Name = "GestionVehiculosToolStripMenuItem";
            this.GestionVehiculosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.GestionVehiculosToolStripMenuItem.Text = "Gestion Vehiculos";
            // 
            // EdicionToolStripMenuItem
            // 
            this.EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem";
            this.EdicionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.EdicionToolStripMenuItem.Text = "Edicion";
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EdicionToolStripMenuItem,
            this.AccionesToolStripMenuItem,
            this.AyudaToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(906, 24);
            this.MenuStrip1.TabIndex = 29;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(541, 14);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(61, 13);
            this.Label15.TabIndex = 16;
            this.Label15.Text = "000000100";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(487, 14);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(38, 13);
            this.Label14.TabIndex = 15;
            this.Label14.Text = "Póliza:";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(278, 14);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(128, 13);
            this.Label13.TabIndex = 1;
            this.Label13.Text = "Automotores - Op. Normal";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Label15);
            this.Panel2.Controls.Add(this.Label14);
            this.Panel2.Controls.Add(this.Label13);
            this.Panel2.Location = new System.Drawing.Point(0, 37);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(879, 40);
            this.Panel2.TabIndex = 30;
            // 
            // DetallePoliza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 487);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.MenuStrip1);
            this.Controls.Add(this.Panel2);
            this.Name = "DetallePoliza";
            this.Text = "DetallePoliza";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Asegurado;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        internal System.Windows.Forms.DataGridViewTextBoxColumn primaColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn tasaColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn sumaColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn numPolizaColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn selColumna;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Prima;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.ToolStripMenuItem AyudaToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem VerVehiculoToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem VerDetalleFacturaToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem GestionFacturasToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem VerClientesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem GestionClientesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem BuscarPólizaToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EmisiónDePólizasToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem GestionPólizasToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AccionesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem GestionVehiculosToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EdicionToolStripMenuItem;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Panel Panel2;
    }
}