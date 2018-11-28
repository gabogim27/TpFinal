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
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.txtTelFijo = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnAdmiFamilia = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Button8 = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.gbGrillaUsuarios = new System.Windows.Forms.GroupBox();
            this.btnMostrarInactivos = new System.Windows.Forms.Button();
            this.btnMostrarActivos = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.rdbSexo2 = new System.Windows.Forms.RadioButton();
            this.rdbSexo = new System.Windows.Forms.RadioButton();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox3.SuspendLayout();
            this.gbGrillaUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(124, 170);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(100, 20);
            this.txtCelular.TabIndex = 18;
            this.txtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCelular_KeyPress);
            // 
            // txtTelFijo
            // 
            this.txtTelFijo.Location = new System.Drawing.Point(124, 142);
            this.txtTelFijo.Name = "txtTelFijo";
            this.txtTelFijo.Size = new System.Drawing.Size(100, 20);
            this.txtTelFijo.TabIndex = 17;
            this.txtTelFijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelFijo_KeyPress);
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(121, 25);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(100, 20);
            this.txtDomicilio.TabIndex = 15;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(6, 113);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(56, 13);
            this.Label11.TabIndex = 15;
            this.Label11.Text = "Localidad:";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(2, 149);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(71, 13);
            this.Label9.TabIndex = 13;
            this.Label9.Text = "Telefono Fijo:";
            this.Label9.Click += new System.EventHandler(this.Label9_Click);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(12, 177);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(42, 13);
            this.Label8.TabIndex = 12;
            this.Label8.Text = "Celular:";
            this.Label8.Click += new System.EventHandler(this.Label8_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(2, 28);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(52, 13);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "Domicilio:";
            this.Label6.Click += new System.EventHandler(this.Label6_Click);
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
            // Button5
            // 
            this.Button5.Location = new System.Drawing.Point(9, 177);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(144, 30);
            this.Button5.TabIndex = 8;
            this.Button5.Text = "Bloquear ";
            this.Button5.UseVisualStyleBackColor = true;
            this.Button5.Click += new System.EventHandler(this.Button5_Click);
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
            this.GroupBox3.Controls.Add(this.Button5);
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
            this.gbGrillaUsuarios.Size = new System.Drawing.Size(789, 279);
            this.gbGrillaUsuarios.TabIndex = 16;
            this.gbGrillaUsuarios.TabStop = false;
            this.gbGrillaUsuarios.Text = "Usuario";
            // 
            // btnMostrarInactivos
            // 
            this.btnMostrarInactivos.Location = new System.Drawing.Point(434, 240);
            this.btnMostrarInactivos.Name = "btnMostrarInactivos";
            this.btnMostrarInactivos.Size = new System.Drawing.Size(144, 30);
            this.btnMostrarInactivos.TabIndex = 12;
            this.btnMostrarInactivos.Text = "Ver Usuarios Inactivos";
            this.btnMostrarInactivos.UseVisualStyleBackColor = true;
            this.btnMostrarInactivos.Click += new System.EventHandler(this.btnMostrarInactivos_Click);
            // 
            // btnMostrarActivos
            // 
            this.btnMostrarActivos.Location = new System.Drawing.Point(124, 240);
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
            this.dgvUsuarios.Location = new System.Drawing.Point(3, 19);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(749, 215);
            this.dgvUsuarios.StandardTab = true;
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            this.dgvUsuarios.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_RowEnter);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtCp);
            this.GroupBox2.Controls.Add(this.label3);
            this.GroupBox2.Controls.Add(this.cboLocalidad);
            this.GroupBox2.Controls.Add(this.cboProvincia);
            this.GroupBox2.Controls.Add(this.label13);
            this.GroupBox2.Controls.Add(this.txtCelular);
            this.GroupBox2.Controls.Add(this.txtTelFijo);
            this.GroupBox2.Controls.Add(this.txtDomicilio);
            this.GroupBox2.Controls.Add(this.Label11);
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Location = new System.Drawing.Point(412, 325);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(361, 214);
            this.GroupBox2.TabIndex = 14;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Otros datos";
            // 
            // txtCp
            // 
            this.txtCp.Location = new System.Drawing.Point(121, 51);
            this.txtCp.Name = "txtCp";
            this.txtCp.Size = new System.Drawing.Size(100, 20);
            this.txtCp.TabIndex = 23;
            this.txtCp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCp_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Código Postal:";
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(121, 105);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(121, 21);
            this.cboLocalidad.TabIndex = 21;
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(121, 78);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(121, 21);
            this.cboProvincia.TabIndex = 20;
            this.cboProvincia.SelectionChangeCommitted += new System.EventHandler(this.cboProvincia_SelectionChangeCommitted);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Provincia:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtEmail);
            this.GroupBox1.Controls.Add(this.txtApellido);
            this.GroupBox1.Controls.Add(this.txtNombre);
            this.GroupBox1.Controls.Add(this.rdbSexo2);
            this.GroupBox1.Controls.Add(this.rdbSexo);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(15, 325);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(361, 203);
            this.GroupBox1.TabIndex = 13;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Datos";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(121, 131);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 15;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(121, 84);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 10;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(121, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 9;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // rdbSexo2
            // 
            this.rdbSexo2.AutoSize = true;
            this.rdbSexo2.Location = new System.Drawing.Point(217, 177);
            this.rdbSexo2.Name = "rdbSexo2";
            this.rdbSexo2.Size = new System.Drawing.Size(51, 17);
            this.rdbSexo2.TabIndex = 6;
            this.rdbSexo2.TabStop = true;
            this.rdbSexo2.Text = "Mujer";
            this.rdbSexo2.UseVisualStyleBackColor = true;
            // 
            // rdbSexo
            // 
            this.rdbSexo.AutoSize = true;
            this.rdbSexo.Location = new System.Drawing.Point(121, 177);
            this.rdbSexo.Name = "rdbSexo";
            this.rdbSexo.Size = new System.Drawing.Size(62, 17);
            this.rdbSexo.TabIndex = 5;
            this.rdbSexo.TabStop = true;
            this.rdbSexo.Text = "Hombre";
            this.rdbSexo.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(5, 179);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(34, 13);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Sexo:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 131);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(38, 13);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "E-mail:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(7, 90);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(47, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Apellido:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(7, 47);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(47, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Nombre:";
            // 
            // frmABMUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 558);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.gbGrillaUsuarios);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "frmABMUsuarios";
            this.Text = "ABMUsuarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmABMUsuarios_FormClosing);
            this.Load += new System.EventHandler(this.ABMUsuarios_Load);
            this.Enter += new System.EventHandler(this.frmABMUsuarios_Enter);
            this.GroupBox3.ResumeLayout(false);
            this.gbGrillaUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.TextBox txtCelular;
        internal System.Windows.Forms.TextBox txtTelFijo;
        internal System.Windows.Forms.TextBox txtDomicilio;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button btnCrearUsuario;
        internal System.Windows.Forms.Button btnDesbloquear;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.Button btnEliminarUsuario;
        internal System.Windows.Forms.Button btnAdmiFamilia;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button Button8;
        internal System.Windows.Forms.Button btnEditarUsuario;
        internal System.Windows.Forms.GroupBox gbGrillaUsuarios;
        internal System.Windows.Forms.DataGridView dgvUsuarios;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.TextBox txtApellido;
        internal System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.RadioButton rdbSexo2;
        internal System.Windows.Forms.RadioButton rdbSexo;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cboProvincia;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox cboLocalidad;
        internal System.Windows.Forms.TextBox txtCp;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btnMostrarActivos;
        internal System.Windows.Forms.Button btnMostrarInactivos;
    }
}