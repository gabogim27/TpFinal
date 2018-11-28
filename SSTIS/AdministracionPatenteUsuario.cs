﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using BLL.Interfaces;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class frmAdministracionPatenteUsuario : Form, IAdminPatenteUsuario
    {
        public IServicioPatente ServicioPatente;
        public IServicioFamilia ServicioFamiliaImplementor;

        public frmAdministracionPatenteUsuario(IServicioPatente ServicioPatente, IServicioFamilia ServicioFamiliaImplementor)
        {
            this.ServicioFamiliaImplementor = ServicioFamiliaImplementor;
            this.ServicioPatente = ServicioPatente;
            InitializeComponent();
        }

        private Usuario UsuarioSeleccionado = new Usuario();
        private List<Patente> Patentes = new List<Patente>();

        private void frmAdministracionPatenteUsuario_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void CargaInicial()
        {
            UsuarioSeleccionado = Program.simpleInyectorContainer.GetInstance<IABMUsuarios>().usuarioSeleccionado();
            lblUsuario.Text = UsuarioSeleccionado.Email;
            dgvAdminPatenteUsuario.Rows.Clear();
            CargarGrilla();
            dgvAdminPatenteUsuario.Columns[1].ReadOnly = false;
            dgvAdminPatenteUsuario.Columns[2].ReadOnly = false;
        }

        private void CargarGrilla()
        {
            var patentesUsuario =
                ServicioPatente.TraerPatenteDescrUsuario(UsuarioSeleccionado.IdUsuario);
            Patentes = ServicioPatente.RetrievePatentes();
            dgvAdminPatenteUsuario.Rows.Clear();

            for (int i = 0; i < Patentes.Count; i++)
            {
                dgvAdminPatenteUsuario.Rows.Add(Patentes[i].Descripcion,
                    patentesUsuario.Any(p => p.IdPatente == Patentes[i].IdPatente),
                    patentesUsuario.Any(p => p.IdPatente == Patentes[i].IdPatente && p.Negada));
            }
        }

        public bool CheckeoPatentes(Usuario usuario)
        {
            var returnValue = true;

            returnValue = ServicioPatente.CheckeoDePatentesParaBorrar(usuario);

            return returnValue;

        }


        private void dgvAdminPatenteUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAdminPatenteUsuario.CurrentCell is DataGridViewCheckBoxCell)
            {
                if (UsuarioSeleccionado != null)
                {
                    DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvAdminPatenteUsuario.CurrentCell;

                    bool isChecked = (bool)checkbox.EditedFormattedValue;
                    var patenteDescripcion = dgvAdminPatenteUsuario.CurrentRow.Cells[0].Value.ToString();
                    var idPatente = Patentes.FirstOrDefault(f => f.Descripcion == patenteDescripcion).IdPatente;
                    //Otorgada
                    if (checkbox.ColumnIndex == 1 && isChecked)
                    {
                        ServicioPatente.GuardarPatenteUsuario(idPatente, UsuarioSeleccionado.IdUsuario);
                    }
                    else if (checkbox.ColumnIndex == 1 && !isChecked)
                    {
                        if (CheckeoPatentes(UsuarioSeleccionado))
                        {
                            ServicioPatente.BorrarPatenteUsuario(idPatente, UsuarioSeleccionado.IdUsuario);
                        }
                        else
                        {
                            MessageBox.Show("Al menos un usuario debe tener asignada esta patente.");
                        }
                    }
                    else if (checkbox.ColumnIndex == 2 && isChecked)
                    {
                        var existePatenteUsuario = ServicioPatente.ConsultarUsuarioPatente(
                            UsuarioSeleccionado.IdUsuario,
                            idPatente);
                        UsuarioSeleccionado.Familia = new List<Familia>();
                        UsuarioSeleccionado.Familia = ServicioFamiliaImplementor.ObtenerFamiliasUsuario(UsuarioSeleccionado.IdUsuario);

                        if (existePatenteUsuario.Count > 0)
                        {
                            if (CheckeoPatentes(UsuarioSeleccionado))
                            {
                                ServicioPatente.NegarPatenteUsuario(idPatente, UsuarioSeleccionado.IdUsuario);
                            }
                            else
                            {
                                MessageBox.Show("Al menos un usuario debe tener asignada esta patente.");
                            }

                        }
                        else if (CheckeoPatentes(UsuarioSeleccionado))
                        {
                            //Primerio guardamos la patente y luego la negamos
                            ServicioPatente.GuardarPatenteUsuario(idPatente, UsuarioSeleccionado.IdUsuario);
                            ServicioPatente.NegarPatenteUsuario(idPatente, UsuarioSeleccionado.IdUsuario);
                            //dgvAdminPatenteUsuario.EndEdit();
                            //checkbox.Value = checkbox.FalseValue;
                        }
                        else
                        {
                            MessageBox.Show("Al menos un usuario debe tener asignada esta patente.");
                        }
                    }
                    else if (checkbox.ColumnIndex == 2 && !isChecked)
                    {
                        ServicioPatente.HabilitarPatenteUsuario(idPatente, UsuarioSeleccionado.IdUsuario);
                    }
                    CargarGrilla();
                }
                DialogResult = DialogResult.None;
            }
        }

        private void frmAdministracionPatenteUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void frmAdministracionPatenteUsuario_Enter(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
