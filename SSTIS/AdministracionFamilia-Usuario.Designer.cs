namespace SSTIS
{
    partial class AdministracionFamilia_Usuario
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.TextBox1);
            this.GroupBox1.Location = new System.Drawing.Point(67, 140);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(200, 221);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Familias";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(18, 34);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(164, 177);
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Text = "Familia 1\r\nFamilia 2\r\nFamilia 3\r\nFamilia 4";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.TextBox2);
            this.GroupBox2.Location = new System.Drawing.Point(534, 140);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(200, 221);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Familia-Usuario";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(15, 38);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(164, 177);
            this.TextBox2.TabIndex = 1;
            this.TextBox2.Text = "Familia 1\r\nFamilia 2\r\nFamilia 3\r\nFamilia 4";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(67, 90);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "USUARIO";
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(337, 260);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(112, 38);
            this.Button2.TabIndex = 8;
            this.Button2.Text = "Quitar";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(337, 174);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(112, 38);
            this.Button1.TabIndex = 7;
            this.Button1.Text = "Asignar";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // AdministracionFamilia_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Name = "AdministracionFamilia_Usuario";
            this.Text = "AdministracionFamilia_Usuario";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
    }
}