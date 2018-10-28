namespace SSTIS
{
    partial class RestaurarCopiaDeSeguridad
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
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(404, 90);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(116, 37);
            this.btnRestaurar.TabIndex = 7;
            this.btnRestaurar.Text = "Restaurar copia de seguridad";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(404, 144);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 36);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(31, 38);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(153, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Seleccione copia de seguridad";
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(215, 79);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(116, 37);
            this.btnExaminar.TabIndex = 8;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(34, 79);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(150, 36);
            this.txtPath.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(32, 144);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 49;
            this.lblStatus.Text = "Status:";
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.Location = new System.Drawing.Point(156, 206);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(21, 13);
            this.lblProgreso.TabIndex = 48;
            this.lblProgreso.Text = "0%";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(34, 175);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(297, 26);
            this.progressBar1.TabIndex = 47;
            // 
            // RestaurarCopiaDeSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 226);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblProgreso);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.Label1);
            this.Name = "RestaurarCopiaDeSeguridad";
            this.Text = "CopiaDeSeguridad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnRestaurar;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblProgreso;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}