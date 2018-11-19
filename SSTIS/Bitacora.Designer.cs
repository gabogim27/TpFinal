namespace SSTIS
{
    partial class frmBitacora
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.BitacoraViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.chklCriticidad = new System.Windows.Forms.CheckedListBox();
            this.chklUsuario = new System.Windows.Forms.CheckedListBox();
            this.rpvBitacora = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BitacoraViewModelBindingSource
            // 
            this.BitacoraViewModelBindingSource.DataSource = typeof(SSTIS.BitacoraViewModel);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(562, 140);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(143, 32);
            this.btnBuscar.TabIndex = 28;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(609, 36);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(50, 13);
            this.Label4.TabIndex = 27;
            this.Label4.Text = "Criticidad";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(396, 36);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(43, 13);
            this.Label3.TabIndex = 26;
            this.Label3.Text = "Usuario";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(100, 67);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 18;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(100, 29);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 17;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 67);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(35, 13);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "Hasta";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 36);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(38, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Desde";
            // 
            // chklCriticidad
            // 
            this.chklCriticidad.FormattingEnabled = true;
            this.chklCriticidad.Location = new System.Drawing.Point(562, 29);
            this.chklCriticidad.Name = "chklCriticidad";
            this.chklCriticidad.Size = new System.Drawing.Size(182, 94);
            this.chklCriticidad.TabIndex = 30;
            // 
            // chklUsuario
            // 
            this.chklUsuario.FormattingEnabled = true;
            this.chklUsuario.Location = new System.Drawing.Point(349, 29);
            this.chklUsuario.Name = "chklUsuario";
            this.chklUsuario.Size = new System.Drawing.Size(187, 94);
            this.chklUsuario.TabIndex = 31;
            // 
            // rpvBitacora
            // 
            reportDataSource1.Name = "DS_Bitacora";
            reportDataSource1.Value = this.BitacoraViewModelBindingSource;
            this.rpvBitacora.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvBitacora.LocalReport.DisplayName = "Sistema TIS";
            this.rpvBitacora.LocalReport.ReportEmbeddedResource = "SSTIS.Reportes.Bitacora.Report1.rdlc";
            this.rpvBitacora.Location = new System.Drawing.Point(15, 189);
            this.rpvBitacora.Name = "rpvBitacora";
            this.rpvBitacora.ServerReport.BearerToken = null;
            this.rpvBitacora.Size = new System.Drawing.Size(781, 320);
            this.rpvBitacora.TabIndex = 33;
            // 
            // frmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 521);
            this.Controls.Add(this.rpvBitacora);
            this.Controls.Add(this.chklUsuario);
            this.Controls.Add(this.chklCriticidad);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "frmBitacora";
            this.Text = "Bitacora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBitacora_FormClosing);
            this.Load += new System.EventHandler(this.Bitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DateTimePicker dtpHasta;
        internal System.Windows.Forms.DateTimePicker dtpDesde;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.CheckedListBox chklCriticidad;
        private System.Windows.Forms.CheckedListBox chklUsuario;
        private System.Windows.Forms.BindingSource BitacoraViewModelBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer rpvBitacora;
    }
}