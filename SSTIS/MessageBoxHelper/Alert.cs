using System.Collections;
using System.Resources;
using System.Windows.Forms;
using log4net;
using SSTIS.Providers;
using SSTIS.Utils;

namespace SSTIS.MessageBoxHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Alert
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Alert));

        public static void ShowSimpleAlert(string msj, string messageNumber = null)
        {
            var mensaje = ProcessMessage(messageNumber);
            MessageBox.Show(mensaje);
        }

        public static void ShowAlterWithButtonAndIcon(string msj, string title, MessageBoxButtons buttons, MessageBoxIcon icon, string messageNumber = null)
        {
            var mensaje = ProcessMessage(messageNumber);
            MessageBox.Show(mensaje, title, buttons, icon);
        }

        public static DialogResult ConfirmationMessage(string messageCode, string title, MessageBoxButtons buttons)
        {
            var mensaje = ProcessMessage(messageCode);
            return MessageBox.Show(mensaje, "Salir del sistema", MessageBoxButtons.YesNo);
        }

        private static string ProcessMessage(string messageNumber)
        {
            try
            {
                using (ResXResourceSet resxSet = new ResXResourceSet(LoginInfo.ResourcesFilePath))
                {
                    foreach (DictionaryEntry item in resxSet)
                    {
                        if (item.Key != null && (string)item.Key == messageNumber)
                        {
                            return item.Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Ocurrio un error al leer el idioma del archivo de recursos. Error: {0}", ex.Message);
            }

            return null;
        }
    }
}
