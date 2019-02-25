namespace SSTIS
{
    partial class DetalleVehiculo
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
            this.dgvVehiculo = new System.Windows.Forms.DataGridView();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.llQuitar = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculo)).BeginInit();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 49);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(140, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Ingrese Número de Patente:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(275, 44);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvVehiculo
            // 
            this.dgvVehiculo.AllowUserToAddRows = false;
            this.dgvVehiculo.AllowUserToDeleteRows = false;
            this.dgvVehiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehiculo.Location = new System.Drawing.Point(6, 112);
            this.dgvVehiculo.Name = "dgvVehiculo";
            this.dgvVehiculo.ReadOnly = true;
            this.dgvVehiculo.Size = new System.Drawing.Size(873, 150);
            this.dgvVehiculo.TabIndex = 0;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(153, 46);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(100, 20);
            this.txtPatente.TabIndex = 8;
            this.txtPatente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatente_KeyPress);
            // 
            // llQuitar
            // 
            this.llQuitar.AutoSize = true;
            this.llQuitar.Location = new System.Drawing.Point(812, 87);
            this.llQuitar.Name = "llQuitar";
            this.llQuitar.Size = new System.Drawing.Size(65, 13);
            this.llQuitar.TabIndex = 36;
            this.llQuitar.TabStop = true;
            this.llQuitar.Text = "Quitar Filtros";
            this.llQuitar.Click += new System.EventHandler(this.llQuitar_Click);
            // 
            // DetalleVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 381);
            this.Controls.Add(this.llQuitar);
            this.Controls.Add(this.txtPatente);
            this.Controls.Add(this.dgvVehiculo);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DetalleVehiculo";
            this.Text = "DetalleVehiculo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DetalleVehiculo_FormClosing);
            this.Load += new System.EventHandler(this.DetalleVehiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.DataGridView dgvVehiculo;
        internal System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.LinkLabel llQuitar;
    }
}