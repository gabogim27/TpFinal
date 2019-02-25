namespace SSTIS
{
    partial class DetalleFactura
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
            this.llQuitar = new System.Windows.Forms.LinkLabel();
            this.txtNumFac = new System.Windows.Forms.TextBox();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // llQuitar
            // 
            this.llQuitar.AutoSize = true;
            this.llQuitar.Location = new System.Drawing.Point(820, 42);
            this.llQuitar.Name = "llQuitar";
            this.llQuitar.Size = new System.Drawing.Size(65, 13);
            this.llQuitar.TabIndex = 14;
            this.llQuitar.TabStop = true;
            this.llQuitar.Text = "Quitar Filtros";
            this.llQuitar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llQuitar_LinkClicked);
            // 
            // txtNumFac
            // 
            this.txtNumFac.Location = new System.Drawing.Point(167, 34);
            this.txtNumFac.Name = "txtNumFac";
            this.txtNumFac.Size = new System.Drawing.Size(100, 20);
            this.txtNumFac.TabIndex = 13;
            this.txtNumFac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumFac_KeyPress);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Location = new System.Drawing.Point(12, 81);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.Size = new System.Drawing.Size(873, 150);
            this.dgvFacturas.TabIndex = 10;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(19, 37);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(136, 13);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Ingrese Número de factura:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(289, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // DetalleFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 313);
            this.Controls.Add(this.llQuitar);
            this.Controls.Add(this.txtNumFac);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DetalleFactura";
            this.Text = "DetalleFactura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DetalleFactura_FormClosing);
            this.Load += new System.EventHandler(this.DetalleFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llQuitar;
        internal System.Windows.Forms.TextBox txtNumFac;
        internal System.Windows.Forms.DataGridView dgvFacturas;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnBuscar;
    }
}