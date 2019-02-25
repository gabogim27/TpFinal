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
            this.Label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvCliente = new System.Windows.Forms.DataGridView();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.llQuitar = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(19, 46);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(67, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Ingrese DNI:";
            this.Label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(232, 41);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvCliente
            // 
            this.dgvCliente.AllowUserToAddRows = false;
            this.dgvCliente.AllowUserToDeleteRows = false;
            this.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCliente.Location = new System.Drawing.Point(12, 90);
            this.dgvCliente.Name = "dgvCliente";
            this.dgvCliente.ReadOnly = true;
            this.dgvCliente.Size = new System.Drawing.Size(873, 150);
            this.dgvCliente.TabIndex = 0;
            this.dgvCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCliente_CellContentClick);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(110, 43);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 8;
            this.txtDni.TextChanged += new System.EventHandler(this.txtDni_TextChanged);
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // llQuitar
            // 
            this.llQuitar.AutoSize = true;
            this.llQuitar.Location = new System.Drawing.Point(820, 51);
            this.llQuitar.Name = "llQuitar";
            this.llQuitar.Size = new System.Drawing.Size(65, 13);
            this.llQuitar.TabIndex = 9;
            this.llQuitar.TabStop = true;
            this.llQuitar.Text = "Quitar Filtros";
            this.llQuitar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llQuitar_LinkClicked);
            this.llQuitar.Click += new System.EventHandler(this.llQuitar_Click);
            // 
            // DetalleCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 361);
            this.Controls.Add(this.llQuitar);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.dgvCliente);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DetalleCliente";
            this.Text = "DetalleCliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DetalleCliente_FormClosing);
            this.Load += new System.EventHandler(this.DetalleCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.DataGridView dgvCliente;
        internal System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.LinkLabel llQuitar;
    }
}