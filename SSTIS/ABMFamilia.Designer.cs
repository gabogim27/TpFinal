namespace SSTIS
{
    partial class frmABMFamilia
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
            this.chklFamilias = new System.Windows.Forms.CheckedListBox();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnModificarPatentes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chklFamilias
            // 
            this.chklFamilias.FormattingEnabled = true;
            this.chklFamilias.Location = new System.Drawing.Point(11, 11);
            this.chklFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.chklFamilias.Name = "chklFamilias";
            this.chklFamilias.Size = new System.Drawing.Size(141, 169);
            this.chklFamilias.TabIndex = 10;
            this.chklFamilias.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklFamilias_ItemCheck);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(158, 152);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(2);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(105, 28);
            this.btnBaja.TabIndex = 9;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(158, 57);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(105, 28);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar Familia";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.Location = new System.Drawing.Point(158, 11);
            this.btnNueva.Margin = new System.Windows.Forms.Padding(2);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(105, 28);
            this.btnNueva.TabIndex = 7;
            this.btnNueva.Text = "Nueva";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnModificarPatentes
            // 
            this.btnModificarPatentes.Location = new System.Drawing.Point(158, 105);
            this.btnModificarPatentes.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificarPatentes.Name = "btnModificarPatentes";
            this.btnModificarPatentes.Size = new System.Drawing.Size(105, 28);
            this.btnModificarPatentes.TabIndex = 11;
            this.btnModificarPatentes.Text = "Modificar Patentes";
            this.btnModificarPatentes.UseVisualStyleBackColor = true;
            this.btnModificarPatentes.Click += new System.EventHandler(this.btnModificarPatentes_Click);
            // 
            // frmABMFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 205);
            this.Controls.Add(this.btnModificarPatentes);
            this.Controls.Add(this.chklFamilias);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNueva);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmABMFamilia";
            this.Text = "ABMFamilia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmABMFamilia_FormClosing);
            this.Load += new System.EventHandler(this.frmABMFamilia_Load);
            this.Enter += new System.EventHandler(this.frmABMFamilia_Enter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklFamilias;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnModificarPatentes;
    }
}