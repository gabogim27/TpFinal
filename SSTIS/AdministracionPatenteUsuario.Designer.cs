namespace SSTIS
{
    partial class frmAdministracionPatenteUsuario
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
            this.Label1 = new System.Windows.Forms.Label();
            this.dgvAdminPatenteUsuario = new System.Windows.Forms.DataGridView();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminPatenteUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(51, 64);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "USUARIO:";
            // 
            // dgvAdminPatenteUsuario
            // 
            this.dgvAdminPatenteUsuario.AllowUserToAddRows = false;
            this.dgvAdminPatenteUsuario.AllowUserToDeleteRows = false;
            this.dgvAdminPatenteUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdminPatenteUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Patente,
            this.Column3,
            this.Column4});
            this.dgvAdminPatenteUsuario.Location = new System.Drawing.Point(54, 102);
            this.dgvAdminPatenteUsuario.Name = "dgvAdminPatenteUsuario";
            this.dgvAdminPatenteUsuario.Size = new System.Drawing.Size(441, 205);
            this.dgvAdminPatenteUsuario.TabIndex = 6;
            this.dgvAdminPatenteUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdminPatenteUsuario_CellContentClick);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(163, 64);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(56, 13);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "USUARIO";
            // 
            // Patente
            // 
            this.Patente.HeaderText = "Patente";
            this.Patente.Name = "Patente";
            this.Patente.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Otorgada";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Negada";
            this.Column4.Name = "Column4";
            // 
            // frmAdministracionPatenteUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 363);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.dgvAdminPatenteUsuario);
            this.Name = "frmAdministracionPatenteUsuario";
            this.Text = "AdministracionPatenteUsuario";
            this.Load += new System.EventHandler(this.frmAdministracionPatenteUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminPatenteUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView dgvAdminPatenteUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        internal System.Windows.Forms.Label lblUsuario;
    }
}