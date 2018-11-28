namespace SSTIS
{
    partial class frmCambiarContraseña
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
            this.btnCambiarPassword = new System.Windows.Forms.Button();
            this.txtConfirmeNueva = new System.Windows.Forms.TextBox();
            this.txtNueva = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(102, 47);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(121, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "CAMBIAR PASSWORD";
            // 
            // btnCambiarPassword
            // 
            this.btnCambiarPassword.Location = new System.Drawing.Point(114, 170);
            this.btnCambiarPassword.Name = "btnCambiarPassword";
            this.btnCambiarPassword.Size = new System.Drawing.Size(166, 39);
            this.btnCambiarPassword.TabIndex = 8;
            this.btnCambiarPassword.Text = "Cambiar Password";
            this.btnCambiarPassword.UseVisualStyleBackColor = true;
            this.btnCambiarPassword.Click += new System.EventHandler(this.btnCambiarPassword_Click);
            // 
            // txtConfirmeNueva
            // 
            this.txtConfirmeNueva.Location = new System.Drawing.Point(114, 125);
            this.txtConfirmeNueva.Name = "txtConfirmeNueva";
            this.txtConfirmeNueva.Size = new System.Drawing.Size(166, 20);
            this.txtConfirmeNueva.TabIndex = 7;
            this.txtConfirmeNueva.UseSystemPasswordChar = true;
            // 
            // txtNueva
            // 
            this.txtNueva.Location = new System.Drawing.Point(114, 83);
            this.txtNueva.Name = "txtNueva";
            this.txtNueva.Size = new System.Drawing.Size(166, 20);
            this.txtNueva.TabIndex = 6;
            this.txtNueva.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nueva Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Confirme Contraseña";
            // 
            // frmCambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 238);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnCambiarPassword);
            this.Controls.Add(this.txtConfirmeNueva);
            this.Controls.Add(this.txtNueva);
            this.Name = "frmCambiarContraseña";
            this.Text = "CambiarContraseña";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCambiarContraseña_FormClosing);
            this.Load += new System.EventHandler(this.frmCambiarContraseña_Load);
            this.Enter += new System.EventHandler(this.frmCambiarContraseña_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnCambiarPassword;
        internal System.Windows.Forms.TextBox txtConfirmeNueva;
        internal System.Windows.Forms.TextBox txtNueva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}