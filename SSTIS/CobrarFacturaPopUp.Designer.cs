namespace SSTIS
{
    partial class CobrarFacturaPopUp
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMontoACobrar = new System.Windows.Forms.TextBox();
            this.btnCobrarAceptar = new System.Windows.Forms.Button();
            this.btnCobrarCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto a cobrar:";
            // 
            // txtMontoACobrar
            // 
            this.txtMontoACobrar.Enabled = false;
            this.txtMontoACobrar.Location = new System.Drawing.Point(109, 45);
            this.txtMontoACobrar.Name = "txtMontoACobrar";
            this.txtMontoACobrar.Size = new System.Drawing.Size(156, 20);
            this.txtMontoACobrar.TabIndex = 1;
            // 
            // btnCobrarAceptar
            // 
            this.btnCobrarAceptar.Location = new System.Drawing.Point(109, 96);
            this.btnCobrarAceptar.Name = "btnCobrarAceptar";
            this.btnCobrarAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnCobrarAceptar.TabIndex = 2;
            this.btnCobrarAceptar.Text = "Aceptar";
            this.btnCobrarAceptar.UseVisualStyleBackColor = true;
            this.btnCobrarAceptar.Click += new System.EventHandler(this.btnCobrarAceptar_Click);
            // 
            // btnCobrarCancelar
            // 
            this.btnCobrarCancelar.Location = new System.Drawing.Point(190, 96);
            this.btnCobrarCancelar.Name = "btnCobrarCancelar";
            this.btnCobrarCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCobrarCancelar.TabIndex = 3;
            this.btnCobrarCancelar.Text = "Cancelar";
            this.btnCobrarCancelar.UseVisualStyleBackColor = true;
            this.btnCobrarCancelar.Click += new System.EventHandler(this.btnCobrarCancelar_Click);
            // 
            // CobrarFacturaPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 166);
            this.Controls.Add(this.btnCobrarCancelar);
            this.Controls.Add(this.btnCobrarAceptar);
            this.Controls.Add(this.txtMontoACobrar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CobrarFacturaPopUp";
            this.Text = "CobrarFacturaPopUp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CobrarFacturaPopUp_FormClosing);
            this.Load += new System.EventHandler(this.CobrarFacturaPopUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMontoACobrar;
        private System.Windows.Forms.Button btnCobrarAceptar;
        private System.Windows.Forms.Button btnCobrarCancelar;
    }
}