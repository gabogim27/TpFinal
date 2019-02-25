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
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroPolizaBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscarPoliza = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dgvPolizas = new System.Windows.Forms.DataGridView();
            this.numPolizaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.llQuitar = new System.Windows.Forms.LinkLabel();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolizas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Ingrese un número de Póliza";
            // 
            // txtNumeroPolizaBuscar
            // 
            this.txtNumeroPolizaBuscar.Location = new System.Drawing.Point(189, 39);
            this.txtNumeroPolizaBuscar.Name = "txtNumeroPolizaBuscar";
            this.txtNumeroPolizaBuscar.Size = new System.Drawing.Size(140, 20);
            this.txtNumeroPolizaBuscar.TabIndex = 33;
            this.txtNumeroPolizaBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroPolizaBuscar_KeyPress);
            // 
            // btnBuscarPoliza
            // 
            this.btnBuscarPoliza.Location = new System.Drawing.Point(390, 39);
            this.btnBuscarPoliza.Name = "btnBuscarPoliza";
            this.btnBuscarPoliza.Size = new System.Drawing.Size(102, 22);
            this.btnBuscarPoliza.TabIndex = 34;
            this.btnBuscarPoliza.Text = "Buscar";
            this.btnBuscarPoliza.UseVisualStyleBackColor = true;
            this.btnBuscarPoliza.Click += new System.EventHandler(this.btnBuscarPoliza_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.TextBox1);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.dgvPolizas);
            this.GroupBox1.Location = new System.Drawing.Point(12, 91);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(825, 175);
            this.GroupBox1.TabIndex = 35;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Póliza";
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
            // dgvPolizas
            // 
            this.dgvPolizas.AllowUserToAddRows = false;
            this.dgvPolizas.AllowUserToDeleteRows = false;
            this.dgvPolizas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPolizas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numPolizaColumna,
            this.selColumna,
            this.sumaColumna,
            this.Cliente,
            this.Apellido,
            this.Column1,
            this.Email});
            this.dgvPolizas.Location = new System.Drawing.Point(6, 25);
            this.dgvPolizas.Name = "dgvPolizas";
            this.dgvPolizas.ReadOnly = true;
            this.dgvPolizas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPolizas.Size = new System.Drawing.Size(813, 150);
            this.dgvPolizas.TabIndex = 0;
            this.dgvPolizas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPolizas_CellDoubleClick);
            // 
            // numPolizaColumna
            // 
            this.numPolizaColumna.DataPropertyName = "NroPoliza";
            this.numPolizaColumna.HeaderText = "N° Póliza";
            this.numPolizaColumna.Name = "numPolizaColumna";
            this.numPolizaColumna.ReadOnly = true;
            // 
            // selColumna
            // 
            this.selColumna.DataPropertyName = "FechaEmision";
            this.selColumna.HeaderText = "Fecha de Emision";
            this.selColumna.Name = "selColumna";
            this.selColumna.ReadOnly = true;
            // 
            // sumaColumna
            // 
            this.sumaColumna.DataPropertyName = "Estado";
            this.sumaColumna.HeaderText = "Estado";
            this.sumaColumna.Name = "sumaColumna";
            this.sumaColumna.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Nombre";
            this.Cliente.HeaderText = "Cliente - Nombre";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Apellido";
            this.Apellido.HeaderText = "Cliente - Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Dni";
            this.Column1.HeaderText = "Cliente - DNI";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Cliente - E-mail";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetalle);
            this.groupBox2.Location = new System.Drawing.Point(12, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 172);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle Póliza";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(6, 13);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.Size = new System.Drawing.Size(813, 150);
            this.dgvDetalle.TabIndex = 0;
            // 
            // btnAprobar
            // 
            this.btnAprobar.Location = new System.Drawing.Point(878, 238);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(90, 41);
            this.btnAprobar.TabIndex = 37;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Location = new System.Drawing.Point(878, 290);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(90, 41);
            this.btnRechazar.TabIndex = 38;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // llQuitar
            // 
            this.llQuitar.AutoSize = true;
            this.llQuitar.Location = new System.Drawing.Point(766, 75);
            this.llQuitar.Name = "llQuitar";
            this.llQuitar.Size = new System.Drawing.Size(65, 13);
            this.llQuitar.TabIndex = 39;
            this.llQuitar.TabStop = true;
            this.llQuitar.Text = "Quitar Filtros";
            this.llQuitar.Click += new System.EventHandler(this.llQuitar_Click);
            // 
            // DetallePoliza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 510);
            this.Controls.Add(this.llQuitar);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnBuscarPoliza);
            this.Controls.Add(this.txtNumeroPolizaBuscar);
            this.Controls.Add(this.label3);
            this.Name = "DetallePoliza";
            this.Text = "DetallePoliza";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DetallePoliza_FormClosing);
            this.Load += new System.EventHandler(this.DetallePoliza_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolizas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroPolizaBuscar;
        private System.Windows.Forms.Button btnBuscarPoliza;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView dgvPolizas;
        private System.Windows.Forms.DataGridViewTextBoxColumn numPolizaColumna;
        private System.Windows.Forms.DataGridViewTextBoxColumn selColumna;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumaColumna;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.LinkLabel llQuitar;
    }
}