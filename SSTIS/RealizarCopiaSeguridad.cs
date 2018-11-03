using System;
using System.IO;
using DAL.Utils;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo.Agent;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class frmRealizarCopiaSeguridad : Form, IRealizarCopiaSeguridad
    {
        public frmRealizarCopiaSeguridad()
        {
            InitializeComponent();
        }

        private void RealizarCopiaSeguridad_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            var cantVolumenes = Convert.ToInt32(cboVolumen.SelectedItem);
            try
            {
                if (txtUbicacion.Text.Trim() != String.Empty && txtDescripcion.Text.Trim() != String.Empty)
                {
                    var dbServer = new Server(new ServerConnection(SqlUtils.Connection()));
                    var dbBackUp = new Backup() { Action = BackupActionType.Database, Database = "TallerPosta" };
                    //dbBackUp.Devices.AddDevice(@"C:\Data\SistemaTIS.bak", DeviceType.File);
                    for (int i = 0; i < cantVolumenes; i++)
                    {
                        dbBackUp.Devices.AddDevice(txtUbicacion.Text.Trim() + "\\" + txtDescripcion.Text.Trim() + i + ".bak", DeviceType.File);
                    }
                    //dbBackUp.Incremental = true;
                    dbBackUp.Initialize = true;
                    dbBackUp.PercentComplete += DbPercentComplete;
                    dbBackUp.Complete += DbBackUp_Complete;
                    dbBackUp.SqlBackupAsync(dbServer);
                }
                else
                {
                    MessageBoxHelper.Alert.ShowSimpleAlert("Debe seleccionar un path para la ubicacion del archivo backup y setear una descripción");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Alert.ShowAlterWithButtonAndIcon(ex.Message, "Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DbBackUp_Complete(object sender, Microsoft.SqlServer.Management.Common.ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                lblStatus.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = e.Error.Message;
                });
            }
        }

        private void DbPercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.Percent;
                progressBar1.Update();
            });

            lblProgreso.Invoke((MethodInvoker)delegate
            {
                lblProgreso.Text = $"{e.Percent}%";
            });
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog explorerDialog = new System.Windows.Forms.FolderBrowserDialog();
            if (explorerDialog.ShowDialog() == DialogResult.OK)
            {
                txtUbicacion.Text = explorerDialog.SelectedPath;
 
            }
        }

        private void descrBackup_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
