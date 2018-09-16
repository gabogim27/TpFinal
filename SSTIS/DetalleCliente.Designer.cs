namespace SSTIS
{
    partial class DetalleCliente
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
            this.Label3 = new System.Windows.Forms.Label();
            this.Button3 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.selColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numPolizaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tasaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asegurado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.EdicionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(777, 89);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(121, 13);
            this.Label2.TabIndex = 33;
            this.Label2.Text = "DETALLE DE CLIENTE";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 25);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(67, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Ingrese DNI:";
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(225, 20);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(75, 23);
            this.Button3.TabIndex = 6;
            this.Button3.Text = "Buscar";
            this.Button3.UseVisualStyleBackColor = true;
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
            this.GroupBox1.Text = "Detalle Cliente";
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
            this.Prima,
            this.Sexo,
            this.Column1,
            this.colCelular});
            this.DataGridView1.Location = new System.Drawing.Point(0, 28);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(873, 150);
            this.DataGridView1.TabIndex = 0;
            // 
            // selColumna
            // 
            this.selColumna.HeaderText = "Nombre y apellido";
            this.selColumna.Name = "selColumna";
            // 
            // numPolizaColumna
            // 
            this.numPolizaColumna.HeaderText = "E-mail";
            this.numPolizaColumna.Name = "numPolizaColumna";
            // 
            // sumaColumna
            // 
            this.sumaColumna.HeaderText = "DNI";
            this.sumaColumna.Name = "sumaColumna";
            // 
            // tasaColumna
            // 
            this.tasaColumna.HeaderText = "Estado";
            this.tasaColumna.Name = "tasaColumna";
            // 
            // primaColumna
            // 
            this.primaColumna.HeaderText = "Nacionalidad";
            this.primaColumna.Name = "primaColumna";
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Domicilio";
            this.Cliente.Name = "Cliente";
            // 
            // Asegurado
            // 
            this.Asegurado.HeaderText = "Localidad";
            this.Asegurado.Name = "Asegurado";
            // 
            // Prima
            // 
            this.Prima.HeaderText = "Fecha de nacimiento";
            this.Prima.Name = "Prima";
            // 
            // Sexo
            // 
            this.Sexo.HeaderText = "Sexo";
            this.Sexo.Name = "Sexo";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "CUIL";
            this.Column1.Name = "Column1";
            // 
            // colCelular
            // 
            this.colCelular.HeaderText = "Celular";
            this.colCelular.Name = "colCelular";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(103, 22);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(100, 20);
            this.TextBox2.TabIndex = 8;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.TextBox2);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.Button3);
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Location = new System.Drawing.Point(12, 105);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(879, 400);
            this.Panel1.TabIndex = 34;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Label15);
            this.Panel2.Controls.Add(this.Label14);
            this.Panel2.Controls.Add(this.Label13);
            this.Panel2.Location = new System.Drawing.Point(12, 40);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(879, 40);
            this.Panel2.TabIndex = 32;
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
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EdicionToolStripMenuItem,
            this.AccionesToolStripMenuItem,
            this.AyudaToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(907, 24);
            this.MenuStrip1.TabIndex = 31;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // EdicionToolStripMenuItem
            // 
            this.EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem";
            this.EdicionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.EdicionToolStripMenuItem.Text = "Edicion";
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
            this.GestionPólizasToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.GestionPólizasToolStripMenuItem.Text = "Gestion Pólizas";
            // 
            // EmisiónDePólizasToolStripMenuItem
            // 
            this.EmisiónDePólizasToolStripMenuItem.Name = "EmisiónDePólizasToolStripMenuItem";
            this.EmisiónDePólizasToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.EmisiónDePólizasToolStripMenuItem.Text = "Emisión de Pólizas";
            // 
            // BuscarPólizaToolStripMenuItem
            // 
            this.BuscarPólizaToolStripMenuItem.Name = "BuscarPólizaToolStripMenuItem";
            this.BuscarPólizaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.BuscarPólizaToolStripMenuItem.Text = "Ver Pólizas";
            // 
            // GestionClientesToolStripMenuItem
            // 
            this.GestionClientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerClientesToolStripMenuItem});
            this.GestionClientesToolStripMenuItem.Name = "GestionClientesToolStripMenuItem";
            this.GestionClientesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.GestionClientesToolStripMenuItem.Text = "Gestion Clientes";
            // 
            // VerClientesToolStripMenuItem
            // 
            this.VerClientesToolStripMenuItem.Name = "VerClientesToolStripMenuItem";
            this.VerClientesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.VerClientesToolStripMenuItem.Text = "Ver Datos Cliente";
            // 
            // GestionFacturasToolStripMenuItem
            // 
            this.GestionFacturasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerDetalleFacturaToolStripMenuItem});
            this.GestionFacturasToolStripMenuItem.Name = "GestionFacturasToolStripMenuItem";
            this.GestionFacturasToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
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
            this.GestionVehiculosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.GestionVehiculosToolStripMenuItem.Text = "Gestion Vehiculos";
            // 
            // VerVehiculoToolStripMenuItem
            // 
            this.VerVehiculoToolStripMenuItem.Name = "VerVehiculoToolStripMenuItem";
            this.VerVehiculoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.VerVehiculoToolStripMenuItem.Text = "Ver Datos Vehiculo";
            // 
            // AyudaToolStripMenuItem
            // 
            this.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem";
            this.AyudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.AyudaToolStripMenuItem.Text = "Ayuda";
            // 
            // DetalleCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 379);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.MenuStrip1);
            this.Name = "DetalleCliente";
            this.Text = "DetalleCliente";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn selColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn numPolizaColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn sumaColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn tasaColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn primaColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Asegurado;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Prima;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Sexo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colCelular;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem EdicionToolStripMenuItem;
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
    }
}