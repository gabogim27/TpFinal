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
            this.Button1 = new System.Windows.Forms.Button();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(95, 93);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(139, 31);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Aceptar";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ComboBox1
            // 
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(95, 41);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(139, 21);
            this.ComboBox1.TabIndex = 1;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Button1);
            this.GroupBox1.Controls.Add(this.ComboBox1);
            this.GroupBox1.Location = new System.Drawing.Point(41, 41);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(260, 177);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Cambiar Idioma";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(15, 49);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Idioma:";
            // 
            // frmCambiarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 271);
            this.Controls.Add(this.GroupBox1);
            this.Name = "frmCambiarIdioma";
            this.Text = "CambiarIdioma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCambiarIdioma_FormClosing);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label1;
    }
}