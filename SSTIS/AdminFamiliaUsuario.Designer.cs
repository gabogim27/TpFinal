namespace SSTIS
{
    partial class frmAdminFamiliaUsuario
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
            this.dgvFamiliaUsuario = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamiliaUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(31, 44);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 13);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "USUARIO:";
            // 
            // dgvFamiliaUsuario
            // 
            this.dgvFamiliaUsuario.AllowUserToAddRows = false;
            this.dgvFamiliaUsuario.AllowUserToDeleteRows = false;
            this.dgvFamiliaUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFamiliaUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3});
            this.dgvFamiliaUsuario.Location = new System.Drawing.Point(34, 82);
            this.dgvFamiliaUsuario.Name = "dgvFamiliaUsuario";
            this.dgvFamiliaUsuario.Size = new System.Drawing.Size(390, 171);
            this.dgvFamiliaUsuario.TabIndex = 9;
            this.dgvFamiliaUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFamiliaUsuario_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Familia";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Otorgada";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(126, 44);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(56, 13);
            this.lblUsuario.TabIndex = 12;
            this.lblUsuario.Text = "USUARIO";
            // 
            // frmAdminFamiliaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 298);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.dgvFamiliaUsuario);
            this.Name = "frmAdminFamiliaUsuario";
            this.Text = "AdminFamiliaUsuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdminFamiliaUsuario_FormClosing);
            this.Load += new System.EventHandler(this.frmAdminFamiliaUsuario_Load);
            this.Enter += new System.EventHandler(this.frmAdminFamiliaUsuario_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamiliaUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView dgvFamiliaUsuario;
        internal System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
    }
}