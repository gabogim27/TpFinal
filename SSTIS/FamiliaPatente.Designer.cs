namespace SSTIS
{
    partial class frmAdmFamiliaPatente
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
            this.dgvAdminFamiliaPatente = new System.Windows.Forms.DataGridView();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.lblFamiliaText = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Otorgada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminFamiliaPatente)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAdminFamiliaPatente
            // 
            this.dgvAdminFamiliaPatente.AllowUserToAddRows = false;
            this.dgvAdminFamiliaPatente.AllowUserToDeleteRows = false;
            this.dgvAdminFamiliaPatente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdminFamiliaPatente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.Otorgada});
            this.dgvAdminFamiliaPatente.Location = new System.Drawing.Point(32, 99);
            this.dgvAdminFamiliaPatente.Name = "dgvAdminFamiliaPatente";
            this.dgvAdminFamiliaPatente.Size = new System.Drawing.Size(330, 166);
            this.dgvAdminFamiliaPatente.TabIndex = 3;
            this.dgvAdminFamiliaPatente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdminFamiliaPatente_CellContentClick);
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(29, 34);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(42, 13);
            this.lblFamilia.TabIndex = 5;
            this.lblFamilia.Text = "Familia:";
            // 
            // lblFamiliaText
            // 
            this.lblFamiliaText.AutoSize = true;
            this.lblFamiliaText.Location = new System.Drawing.Point(121, 34);
            this.lblFamiliaText.Name = "lblFamiliaText";
            this.lblFamiliaText.Size = new System.Drawing.Size(35, 13);
            this.lblFamiliaText.TabIndex = 6;
            this.lblFamiliaText.Text = "label1";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(287, 24);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Patente";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Otorgada
            // 
            this.Otorgada.HeaderText = "Otorgada";
            this.Otorgada.Name = "Otorgada";
            // 
            // frmAdmFamiliaPatente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 307);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblFamiliaText);
            this.Controls.Add(this.dgvAdminFamiliaPatente);
            this.Controls.Add(this.lblFamilia);
            this.Name = "frmAdmFamiliaPatente";
            this.Text = "FamiliaPatente";
            this.Load += new System.EventHandler(this.frmAdmFamiliaPatente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminFamiliaPatente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvAdminFamiliaPatente;
        internal System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.Label lblFamiliaText;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Otorgada;
    }
}