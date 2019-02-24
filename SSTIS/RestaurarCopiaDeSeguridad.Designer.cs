namespace SSTIS
{
    partial class frmRestaurarCopiaDeSeguridad
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.txtBackFiles = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(404, 32);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(116, 37);
            this.btnRestaurar.TabIndex = 7;
            this.btnRestaurar.Text = "Restaurar copia de seguridad";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(404, 103);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(116, 36);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(153, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Seleccione copia de seguridad";
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(12, 50);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(116, 37);
            this.btnExaminar.TabIndex = 8;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtBackFiles
            // 
            this.txtBackFiles.Location = new System.Drawing.Point(168, 32);
            this.txtBackFiles.Multiline = true;
            this.txtBackFiles.Name = "txtBackFiles";
            this.txtBackFiles.Size = new System.Drawing.Size(216, 95);
            this.txtBackFiles.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
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
            // frmRestaurarCopiaDeSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 226);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblProgreso);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtBackFiles);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmRestaurarCopiaDeSeguridad";
            this.Text = "CopiaDeSeguridad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRestaurarCopiaDeSeguridad_FormClosing);
            this.Load += new System.EventHandler(this.frmRestaurarCopiaDeSeguridad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnRestaurar;
        internal System.Windows.Forms.Button btnVolver;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.TextBox txtBackFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblProgreso;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}