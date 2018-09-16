namespace SysAnalizer
{
    partial class ABMCoberturas
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
            this.Button2 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.selColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coberturaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tasaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button1 = new System.Windows.Forms.Button();
            this.Label19 = new System.Windows.Forms.Label();
            this.Button8 = new System.Windows.Forms.Button();
            this.Button7 = new System.Windows.Forms.Button();
            this.Button6 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button10 = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Button4 = new System.Windows.Forms.Button();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.AyudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EdicionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(20, 71);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 25);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "Restablecer";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.TextBox1);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.DataGridView1);
            this.GroupBox1.Location = new System.Drawing.Point(14, 35);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(588, 379);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Coberturas de una póliza";
            // 
            // TextBox1
            // 
            this.TextBox1.Enabled = false;
            this.TextBox1.Location = new System.Drawing.Point(354, 353);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(195, 20);
            this.TextBox1.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(267, 360);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Prima total:";
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selColumna,
            this.coberturaColumna,
            this.sumaColumna,
            this.tasaColumna,
            this.primaColumna});
            this.DataGridView1.Location = new System.Drawing.Point(6, 19);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(543, 150);
            this.DataGridView1.TabIndex = 0;
            // 
            // selColumna
            // 
            this.selColumna.HeaderText = "Sel";
            this.selColumna.Name = "selColumna";
            // 
            // coberturaColumna
            // 
            this.coberturaColumna.HeaderText = "Cobertura";
            this.coberturaColumna.Name = "coberturaColumna";
            // 
            // sumaColumna
            // 
            this.sumaColumna.HeaderText = "Suma Asegurada";
            this.sumaColumna.Name = "sumaColumna";
            // 
            // tasaColumna
            // 
            this.tasaColumna.HeaderText = "Tasa";
            this.tasaColumna.Name = "tasaColumna";
            // 
            // primaColumna
            // 
            this.primaColumna.HeaderText = "Prima";
            this.primaColumna.Name = "primaColumna";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(20, 13);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 25);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Editar";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(626, 109);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(114, 13);
            this.Label19.TabIndex = 72;
            this.Label19.Text = "DATOS COBERTURA";
            // 
            // Button8
            // 
            this.Button8.Location = new System.Drawing.Point(768, 251);
            this.Button8.Name = "Button8";
            this.Button8.Size = new System.Drawing.Size(75, 34);
            this.Button8.TabIndex = 70;
            this.Button8.Text = "Aceptar";
            this.Button8.UseVisualStyleBackColor = true;
            // 
            // Button7
            // 
            this.Button7.Location = new System.Drawing.Point(472, 531);
            this.Button7.Name = "Button7";
            this.Button7.Size = new System.Drawing.Size(75, 34);
            this.Button7.TabIndex = 69;
            this.Button7.Text = ">>";
            this.Button7.UseVisualStyleBackColor = true;
            // 
            // Button6
            // 
            this.Button6.Location = new System.Drawing.Point(107, 530);
            this.Button6.Name = "Button6";
            this.Button6.Size = new System.Drawing.Size(75, 34);
            this.Button6.TabIndex = 68;
            this.Button6.Text = "<<";
            this.Button6.UseVisualStyleBackColor = true;
            // 
            // Button5
            // 
            this.Button5.Location = new System.Drawing.Point(233, 531);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(75, 34);
            this.Button5.TabIndex = 67;
            this.Button5.Text = "<";
            this.Button5.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(347, 530);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(75, 34);
            this.Button3.TabIndex = 66;
            this.Button3.Text = ">";
            this.Button3.UseVisualStyleBackColor = true;
            // 
            // Button10
            // 
            this.Button10.Location = new System.Drawing.Point(768, 308);
            this.Button10.Name = "Button10";
            this.Button10.Size = new System.Drawing.Size(75, 34);
            this.Button10.TabIndex = 71;
            this.Button10.Text = "Cancelar";
            this.Button10.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.GroupBox3);
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Location = new System.Drawing.Point(12, 125);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(728, 400);
            this.Panel1.TabIndex = 65;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Button4);
            this.GroupBox3.Controls.Add(this.Button2);
            this.GroupBox3.Controls.Add(this.Button1);
            this.GroupBox3.Location = new System.Drawing.Point(606, 168);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(122, 104);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Acciones";
            // 
            // Button4
            // 
            this.Button4.Location = new System.Drawing.Point(20, 42);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(75, 25);
            this.Button4.TabIndex = 3;
            this.Button4.Text = "Eliminar";
            this.Button4.UseVisualStyleBackColor = true;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(541, 14);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(61, 13);
            this.Label15.TabIndex = 16;
            this.Label15.Text = "000000100";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(487, 14);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(38, 13);
            this.Label14.TabIndex = 15;
            this.Label14.Text = "Póliza:";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(278, 14);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(128, 13);
            this.Label13.TabIndex = 1;
            this.Label13.Text = "Automotores - Op. Normal";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Label15);
            this.Panel2.Controls.Add(this.Label14);
            this.Panel2.Controls.Add(this.Label13);
            this.Panel2.Location = new System.Drawing.Point(12, 46);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(728, 40);
            this.Panel2.TabIndex = 64;
            // 
            // AyudaToolStripMenuItem
            // 
            this.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem";
            this.AyudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.AyudaToolStripMenuItem.Text = "Ayuda";
            // 
            // AccionesToolStripMenuItem
            // 
            this.AccionesToolStripMenuItem.Name = "AccionesToolStripMenuItem";
            this.AccionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.AccionesToolStripMenuItem.Text = "Acciones";
            // 
            // EdicionToolStripMenuItem
            // 
            this.EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem";
            this.EdicionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.EdicionToolStripMenuItem.Text = "Edicion";
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EdicionToolStripMenuItem,
            this.AccionesToolStripMenuItem,
            this.AyudaToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(870, 24);
            this.MenuStrip1.TabIndex = 63;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // ABMCoberturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 551);
            this.Controls.Add(this.Label19);
            this.Controls.Add(this.Button8);
            this.Controls.Add(this.Button7);
            this.Controls.Add(this.Button6);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button10);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.MenuStrip1);
            this.Name = "ABMCoberturas";
            this.Text = "ABMCoberturas";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn selColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn coberturaColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn sumaColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn tasaColumna;
        internal System.Windows.Forms.DataGridViewTextBoxColumn primaColumna;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Button Button8;
        internal System.Windows.Forms.Button Button7;
        internal System.Windows.Forms.Button Button6;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button10;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ToolStripMenuItem AyudaToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AccionesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EdicionToolStripMenuItem;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
    }
}