namespace SSTIS
{
    partial class PolizaWizard
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
            this.stwControl = new AeroWizard.StepWizardControl();
            this.wizardPage1 = new AeroWizard.WizardPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.wizardPage2 = new AeroWizard.WizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.stwControl)).BeginInit();
            this.wizardPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stwControl
            // 
            this.stwControl.BackColor = System.Drawing.Color.White;
            this.stwControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stwControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stwControl.Location = new System.Drawing.Point(0, 0);
            this.stwControl.Name = "stwControl";
            this.stwControl.Pages.Add(this.wizardPage1);
            this.stwControl.Pages.Add(this.wizardPage2);
            this.stwControl.Size = new System.Drawing.Size(964, 450);
            this.stwControl.StepListFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.stwControl.TabIndex = 0;
            this.stwControl.Text = "Emisión de Póliza";
            this.stwControl.Title = "Emisión de Póliza";
            this.stwControl.SelectedPageChanged += new System.EventHandler(this.stwControl_SelectedPageChanged);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.textBox1);
            this.wizardPage1.Controls.Add(this.dateTimePicker1);
            this.wizardPage1.Controls.Add(this.label3);
            this.wizardPage1.Controls.Add(this.label2);
            this.wizardPage1.Controls.Add(this.label1);
            this.wizardPage1.Controls.Add(this.comboBox1);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(766, 296);
            this.stwControl.SetStepText(this.wizardPage1, "Emision de Póliza");
            this.wizardPage1.TabIndex = 2;
            this.wizardPage1.Text = "Bienvenidos al Sistema de Emision de Pólizas";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(210, 146);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 23);
            this.textBox1.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(208, 103);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(258, 23);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Número de Póliza";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de emisión";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de Póliza";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(208, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // wizardPage2
            // 
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(766, 296);
            this.stwControl.SetStepText(this.wizardPage2, "Page Title");
            this.wizardPage2.TabIndex = 3;
            this.wizardPage2.Text = "Page Title";
            // 
            // PolizaWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 450);
            this.Controls.Add(this.stwControl);
            this.Name = "PolizaWizard";
            this.Text = "PolizaWizard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PolizaWizard_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.stwControl)).EndInit();
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AeroWizard.StepWizardControl stwControl;
        private AeroWizard.WizardPage wizardPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private AeroWizard.WizardPage wizardPage2;
    }
}