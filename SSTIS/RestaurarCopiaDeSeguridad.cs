using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Utils;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class RestaurarCopiaDeSeguridad : Form, IRestaurarCopiaDeSeguridad
    {
        public RestaurarCopiaDeSeguridad()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            try
            {
                var dbServer = new Server(new ServerConnection(SqlUtils.Connection()));
                var restore = new Restore()
                {
                    Database = "SistemaTIS", Action = RestoreActionType.Database, ReplaceDatabase = true,
                    NoRecovery = false
                };
                restore.Devices.AddDevice(txtPath.Text.Trim(), DeviceType.File);
                restore.PercentComplete += DbPercentComplete;
                restore.Complete += DbRestore_Complete;
                restore.SqlRestoreAsync(dbServer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DbRestore_Complete(object sender, Microsoft.SqlServer.Management.Common.ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                lblStatus.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = e.Error.Message;
                });
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    txtPath.Text = file;
                }
                catch (IOException)
                {
                    MessageBox.Show("Ocurrio un error al examinar el path.");
                }
            }
        }
    }
}
