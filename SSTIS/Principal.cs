﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class frmPrincipal : Form, IPrincipal
    {
        private readonly IABMUsuarios abmUsuarios;
        public frmPrincipal(IABMUsuarios abmUsuarios)
        {
            this.abmUsuarios = abmUsuarios;
            InitializeComponent();
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void Usuarios_Click(object sender, EventArgs e)
        {

            abmUsuarios.Show();
        }
    }
}
