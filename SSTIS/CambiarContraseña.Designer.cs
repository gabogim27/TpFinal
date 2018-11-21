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
            this.txtActual = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnCambiarPassword = new System.Windows.Forms.Button();
            this.txtConfirmeNueva = new System.Windows.Forms.TextBox();
            this.txtNueva = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtActual
            // 
            this.txtActual.Location = new System.Drawing.Point(74, 78);
            this.txtActual.Multiline = true;
            this.txtActual.Name = "txtActual";
            this.txtActual.Size = new System.Drawing.Size(166, 33);
            this.txtActual.TabIndex = 10;
            this.txtActual.Text = "password actual";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(71, 49);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(121, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "CAMBIAR PASSWORD";
            // 
            // btnCambiarPassword
            // 
            this.btnCambiarPassword.Location = new System.Drawing.Point(74, 262);
            this.btnCambiarPassword.Name = "btnCambiarPassword";
            this.btnCambiarPassword.Size = new System.Drawing.Size(166, 39);
            this.btnCambiarPassword.TabIndex = 8;
            this.btnCambiarPassword.Text = "Cambiar Password";
            this.btnCambiarPassword.UseVisualStyleBackColor = true;
            // 
            // txtConfirmeNueva
            // 
            this.txtConfirmeNueva.Location = new System.Drawing.Point(74, 191);
            this.txtConfirmeNueva.Multiline = true;
            this.txtConfirmeNueva.Name = "txtConfirmeNueva";
            this.txtConfirmeNueva.Size = new System.Drawing.Size(166, 33);
            this.txtConfirmeNueva.TabIndex = 7;
            this.txtConfirmeNueva.Text = "confirmar password";
            // 
            // txtNueva
            // 
            this.txtNueva.Location = new System.Drawing.Point(74, 127);
            this.txtNueva.Multiline = true;
            this.txtNueva.Name = "txtNueva";
            this.txtNueva.Size = new System.Drawing.Size(166, 33);
            this.txtNueva.TabIndex = 6;
            this.txtNueva.Text = "nuevo password";
            // 
            // frmCambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 341);
            this.Controls.Add(this.txtActual);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnCambiarPassword);
            this.Controls.Add(this.txtConfirmeNueva);
            this.Controls.Add(this.txtNueva);
            this.Name = "frmCambiarContraseña";
            this.Text = "CambiarContraseña";
            this.Load += new System.EventHandler(this.frmCambiarContraseña_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtActual;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnCambiarPassword;
        internal System.Windows.Forms.TextBox txtConfirmeNueva;
        internal System.Windows.Forms.TextBox txtNueva;
    }
}