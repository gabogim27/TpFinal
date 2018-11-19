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
using SSTIS.MessageBoxHelper;

namespace SSTIS
{
    public partial class frmRestaurarCopiaDeSeguridad : Form, IRestaurarCopiaDeSeguridad
    {
        public frmRestaurarCopiaDeSeguridad()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            try
            {
                if (!string.IsNullOrEmpty(txtBackFiles.Text))
                {
                string[] backupFiles = txtBackFiles.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var dbServer = new Server(new ServerConnection(SqlUtils.Connection()));
                var restore = new Restore()
                {
                    Database = "TallerPosta", Action = RestoreActionType.Database, ReplaceDatabase = true,
                    NoRecovery = false
                };
                for (int i = 0; i < backupFiles.Length; i++)
                {
                    restore.Devices.AddDevice(backupFiles[i], DeviceType.File);
                }

                restore.ReplaceDatabase = true;
                restore.PercentComplete += DbPercentComplete;
                restore.Complete += DbRestore_Complete;
                restore.SqlRestore(dbServer);
                
                Alert.ShowAlterWithButtonAndIcon("Restore completado exitosamente.", "Restore Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor seleccione los archivos .BAK.");
                }

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
            openFileDialog1.Filter = "Backup files(*.bak) |*.bak";
            openFileDialog1.Title = "Por favor seleccione un archivo backup";
            txtBackFiles.Text = String.Empty;
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                    {
                        txtBackFiles.AppendText(openFileDialog1.FileNames[i] + Environment.NewLine);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Ocurrio un error al examinar el path.");
                }
            }
        }

        private void frmRestaurarCopiaDeSeguridad_Load(object sender, EventArgs e)
        {
            txtBackFiles.Enabled = false;
        }

        private void frmRestaurarCopiaDeSeguridad_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
