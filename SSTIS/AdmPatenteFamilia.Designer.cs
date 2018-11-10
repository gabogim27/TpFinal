namespace SSTIS
{
    partial class frmAdminPatenteFamilia
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
            this.lblFamilia = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstPatentes = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(60, 23);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(42, 13);
            this.lblFamilia.TabIndex = 60;
            this.lblFamilia.Text = "Familia:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstPatentes);
            this.groupBox1.Location = new System.Drawing.Point(63, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 169);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PATENTES";
            // 
            // lstPatentes
            // 
            this.lstPatentes.FormattingEnabled = true;
            this.lstPatentes.Items.AddRange(new object[] {
            "Patente 1",
            "Patente 2",
            "Patente 3",
            "Patente 4",
            "Patente 5",
            "Patente 6",
            "Patente 7",
            "Patente 8",
            "Patente 9"});
            this.lstPatentes.Location = new System.Drawing.Point(15, 19);
            this.lstPatentes.Name = "lstPatentes";
            this.lstPatentes.Size = new System.Drawing.Size(152, 139);
            this.lstPatentes.TabIndex = 55;
            // 
            // frmAdminPatenteFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 274);
            this.Controls.Add(this.lblFamilia);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAdminPatenteFamilia";
            this.Text = "AdminFamiliaPatente";
            this.Load += new System.EventHandler(this.ReporteBitacora_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox lstPatentes;
    }
}