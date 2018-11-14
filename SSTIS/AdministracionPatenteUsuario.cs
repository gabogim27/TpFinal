using System;
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
        public frmAdministracionPatenteUsuario(IServicioPatente ServicioPatente)
        {
            this.ServicioPatente = ServicioPatente;
            InitializeComponent();
        }

        public IServicioPatente ServicioPatente;
        private Usuario UsuarioSeleccionado = new Usuario();
        private List<Patente> Patentes = new List<Patente>();

        private void frmAdministracionPatenteUsuario_Load(object sender, EventArgs e)
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

            
            for (int i = 0; i < Patentes.Count; i++)
            {
                dgvAdminPatenteUsuario.Rows.Add(Patentes[i].Descripcion,
                    patentesUsuario.Any(p => p.IdPatente == Patentes[i].IdPatente),
                    //Patentes?.Any(p => patentesUsuario.Any(x => x.IdPatente == p.IdPatente)),
                    patentesUsuario.Any(p => p.IdPatente == Patentes[i].IdPatente && p.Negada));
            }
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
                        ServicioPatente.BorrarPatenteUsuario(idPatente, UsuarioSeleccionado.IdUsuario);
                    }
                    else if (checkbox.ColumnIndex == 2 && isChecked)
                    {
                        var patentesUsuario =
                            ServicioPatente.TraerPatenteDescrUsuario(UsuarioSeleccionado.IdUsuario);
                        if (patentesUsuario.Any(x =>
                            x.IdPatente == idPatente && x.IdUsuario == UsuarioSeleccionado.IdUsuario))
                        {
                            ServicioPatente.NegarPatenteUsuario(idPatente, UsuarioSeleccionado.IdUsuario);
                        }
                        else
                        {
                            MessageBox.Show("Primero debe otorgarle la patente al usuario y luego negarsela.");
                            dgvAdminPatenteUsuario.EndEdit();
                            checkbox.Value = checkbox.FalseValue;
                        }
                    }
                    else if (checkbox.ColumnIndex == 2 && !isChecked)
                    {
                        ServicioPatente.HabilitarPatenteUsuario(idPatente, UsuarioSeleccionado.IdUsuario);
                    }
                }
                DialogResult = DialogResult.None;
            }
        }

        private void frmAdministracionPatenteUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
