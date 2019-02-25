namespace SSTIS
{
    partial class frmABMUsuarios
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
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.btnBloquear = new System.Windows.Forms.Button();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnAdmiFamilia = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Button8 = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.gbGrillaUsuarios = new System.Windows.Forms.GroupBox();
            this.btnMostrarInactivos = new System.Windows.Forms.Button();
            this.btnMostrarActivos = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.GroupBox3.SuspendLayout();
            this.gbGrillaUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.Location = new System.Drawing.Point(9, 34);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(144, 30);
            this.btnCrearUsuario.TabIndex = 10;
            this.btnCrearUsuario.Text = "Crear Usuario";
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.Location = new System.Drawing.Point(6, 363);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(144, 30);
            this.btnDesbloquear.TabIndex = 9;
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(9, 129);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(144, 30);
            this.Button3.TabIndex = 6;
            this.Button3.Text = "Administrar Patentes";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // btnBloquear
            // 
            this.btnBloquear.Location = new System.Drawing.Point(9, 177);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(144, 30);
            this.btnBloquear.TabIndex = 8;
            this.btnBloquear.Text = "Bloquear ";
            this.btnBloquear.UseVisualStyleBackColor = true;
            this.btnBloquear.Click += new System.EventHandler(this.Button5_Click);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Location = new System.Drawing.Point(6, 270);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(144, 30);
            this.btnEliminarUsuario.TabIndex = 5;
            this.btnEliminarUsuario.Text = "Eliminar Usuario";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // btnAdmiFamilia
            // 
            this.btnAdmiFamilia.Location = new System.Drawing.Point(6, 312);
            this.btnAdmiFamilia.Name = "btnAdmiFamilia";
            this.btnAdmiFamilia.Size = new System.Drawing.Size(144, 30);
            this.btnAdmiFamilia.TabIndex = 7;
            this.btnAdmiFamilia.Text = "Administrar Familias";
            this.btnAdmiFamilia.UseVisualStyleBackColor = true;
            this.btnAdmiFamilia.Click += new System.EventHandler(this.btnAdmiFamilia_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Button8);
            this.GroupBox3.Controls.Add(this.btnCrearUsuario);
            this.GroupBox3.Controls.Add(this.btnEditarUsuario);
            this.GroupBox3.Controls.Add(this.btnDesbloquear);
            this.GroupBox3.Controls.Add(this.Button3);
            this.GroupBox3.Controls.Add(this.btnBloquear);
            this.GroupBox3.Controls.Add(this.btnEliminarUsuario);
            this.GroupBox3.Controls.Add(this.btnAdmiFamilia);
            this.GroupBox3.Location = new System.Drawing.Point(839, 12);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(160, 401);
            this.GroupBox3.TabIndex = 15;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Accion";
            // 
            // Button8
            // 
            this.Button8.Location = new System.Drawing.Point(10, 223);
            this.Button8.Name = "Button8";
            this.Button8.Size = new System.Drawing.Size(144, 30);
            this.Button8.TabIndex = 11;
            this.Button8.Text = "Blanqueo de contraseña";
            this.Button8.UseVisualStyleBackColor = true;
            this.Button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.Location = new System.Drawing.Point(9, 84);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(144, 30);
            this.btnEditarUsuario.TabIndex = 4;
            this.btnEditarUsuario.Text = "Editar Usuario";
            this.btnEditarUsuario.UseVisualStyleBackColor = true;
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);
            // 
            // gbGrillaUsuarios
            // 
            this.gbGrillaUsuarios.Controls.Add(this.btnMostrarInactivos);
            this.gbGrillaUsuarios.Controls.Add(this.btnMostrarActivos);
            this.gbGrillaUsuarios.Controls.Add(this.dgvUsuarios);
            this.gbGrillaUsuarios.Location = new System.Drawing.Point(12, 12);
            this.gbGrillaUsuarios.Name = "gbGrillaUsuarios";
            this.gbGrillaUsuarios.Size = new System.Drawing.Size(789, 395);
            this.gbGrillaUsuarios.TabIndex = 16;
            this.gbGrillaUsuarios.TabStop = false;
            this.gbGrillaUsuarios.Text = "Usuario";
            // 
            // btnMostrarInactivos
            // 
            this.btnMostrarInactivos.Location = new System.Drawing.Point(437, 342);
            this.btnMostrarInactivos.Name = "btnMostrarInactivos";
            this.btnMostrarInactivos.Size = new System.Drawing.Size(144, 30);
            this.btnMostrarInactivos.TabIndex = 12;
            this.btnMostrarInactivos.Text = "Ver Usuarios Inactivos";
            this.btnMostrarInactivos.UseVisualStyleBackColor = true;
            this.btnMostrarInactivos.Click += new System.EventHandler(this.btnMostrarInactivos_Click);
            // 
            // btnMostrarActivos
            // 
            this.btnMostrarActivos.Location = new System.Drawing.Point(119, 342);
            this.btnMostrarActivos.Name = "btnMostrarActivos";
            this.btnMostrarActivos.Size = new System.Drawing.Size(144, 30);
            this.btnMostrarActivos.TabIndex = 13;
            this.btnMostrarActivos.Text = "Ver Usuarios Activos";
            this.btnMostrarActivos.UseVisualStyleBackColor = true;
            this.btnMostrarActivos.Click += new System.EventHandler(this.btnMostrarActivos_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 33);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(749, 303);
            this.dgvUsuarios.StandardTab = true;
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            this.dgvUsuarios.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_RowEnter);
            // 
            // frmABMUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 419);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.gbGrillaUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmABMUsuarios";
            this.Text = "ABMUsuarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmABMUsuarios_FormClosing);
            this.Load += new System.EventHandler(this.ABMUsuarios_Load);
            this.Enter += new System.EventHandler(this.frmABMUsuarios_Enter);
            this.GroupBox3.ResumeLayout(false);
            this.gbGrillaUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button btnCrearUsuario;
        internal System.Windows.Forms.Button btnDesbloquear;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button btnBloquear;
        internal System.Windows.Forms.Button btnEliminarUsuario;
        internal System.Windows.Forms.Button btnAdmiFamilia;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button Button8;
        internal System.Windows.Forms.Button btnEditarUsuario;
        internal System.Windows.Forms.GroupBox gbGrillaUsuarios;
        internal System.Windows.Forms.DataGridView dgvUsuarios;
        internal System.Windows.Forms.Button btnMostrarActivos;
        internal System.Windows.Forms.Button btnMostrarInactivos;
    }
}