namespace SSTIS
{
    partial class frmCambiarIdioma
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cboIdioma = new System.Windows.Forms.ComboBox();
            this.grpIdioma = new System.Windows.Forms.GroupBox();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.grpIdioma.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(95, 93);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 31);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.Button1_Click);
            // 
            // cboIdioma
            // 
            this.cboIdioma.FormattingEnabled = true;
            this.cboIdioma.Location = new System.Drawing.Point(95, 41);
            this.cboIdioma.Name = "cboIdioma";
            this.cboIdioma.Size = new System.Drawing.Size(139, 21);
            this.cboIdioma.TabIndex = 1;
            // 
            // grpIdioma
            // 
            this.grpIdioma.Controls.Add(this.lblIdioma);
            this.grpIdioma.Controls.Add(this.btnAceptar);
            this.grpIdioma.Controls.Add(this.cboIdioma);
            this.grpIdioma.Location = new System.Drawing.Point(41, 41);
            this.grpIdioma.Name = "grpIdioma";
            this.grpIdioma.Size = new System.Drawing.Size(260, 177);
            this.grpIdioma.TabIndex = 4;
            this.grpIdioma.TabStop = false;
            this.grpIdioma.Text = "Cambiar Idioma";
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Location = new System.Drawing.Point(15, 49);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(41, 13);
            this.lblIdioma.TabIndex = 3;
            this.lblIdioma.Text = "Idioma:";
            // 
            // frmCambiarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 271);
            this.Controls.Add(this.grpIdioma);
            this.Name = "frmCambiarIdioma";
            this.Text = "CambiarIdioma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCambiarIdioma_FormClosing);
            this.Load += new System.EventHandler(this.frmCambiarIdioma_Load);
            this.grpIdioma.ResumeLayout(false);
            this.grpIdioma.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnAceptar;
        internal System.Windows.Forms.ComboBox cboIdioma;
        internal System.Windows.Forms.GroupBox grpIdioma;
        internal System.Windows.Forms.Label lblIdioma;
    }
}