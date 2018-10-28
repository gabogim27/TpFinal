using System;
using System.IO;
using DAL.Utils;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Forms;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class RealizarCopiaSeguridad : Form, IRealizarCopiaSeguridad
    {
        public RealizarCopiaSeguridad()
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
                var dbServer = new Server(new ServerConnection(SqlUtils.Connection()));
                var dbBackUp = new Backup() { Action = BackupActionType.Database, Database = "SistemaTIS"};
                //dbBackUp.Devices.AddDevice(@"C:\Data\SistemaTIS.bak", DeviceType.File);
                for (int i = 0; i < cantVolumenes; i++)
                {
                    dbBackUp.Devices.AddDevice(txtUbicacion.Text.Trim() + "\\" + descrBackup.Text.Trim() + i + ".bak", DeviceType.File);
                }
                //dbBackUp.Incremental = true;
                dbBackUp.Initialize = true;
                dbBackUp.PercentComplete += DbPercentComplete;
                dbBackUp.Complete += DbBackUp_Complete;
                dbBackUp.SqlBackupAsync(dbServer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Environment.SpecialFolder root = explorerDialog.RootFolder;
            }
        }

        private void descrBackup_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
