namespace SSTIS
{
    partial class CambiarContraseña
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
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBox3
            // 
            this.TextBox3.Location = new System.Drawing.Point(74, 78);
            this.TextBox3.Multiline = true;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(166, 33);
            this.TextBox3.TabIndex = 10;
            this.TextBox3.Text = "password actual";
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
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(74, 262);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(166, 39);
            this.Button1.TabIndex = 8;
            this.Button1.Text = "Cambiar Password";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(74, 191);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(166, 33);
            this.TextBox1.TabIndex = 7;
            this.TextBox1.Text = "confirmar password";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(74, 127);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(166, 33);
            this.TextBox2.TabIndex = 6;
            this.TextBox2.Text = "nuevo password";
            // 
            // CambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 341);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.TextBox2);
            this.Name = "CambiarContraseña";
            this.Text = "CambiarContraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TextBox3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.TextBox TextBox2;
    }
}