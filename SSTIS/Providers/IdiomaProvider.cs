using System.Data;
using System.Resources;
using System.Windows.Forms;
using BE;
using BLL.Interfaces;
using log4net;
using SSTIS.MessageBoxHelper;

namespace SSTIS.Providers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class IdiomaProvider
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(IdiomaProvider));
        public static DataSet ListadoBitacora = new DataSet();
        private static readonly string ResourcesFilePath = "C:\\\\TPFinalDiploma\\\\TpFinal\\\\SSTIS\\\\\\Resources\\\\SpanishResources.resx";

        public static void FillResources(IDictionary<string, string> traducciones, Guid idiomaSeleccionado, string nombreFormulario)
        {
            try
            {
                using (ResXResourceWriter resxWriter = new ResXResourceWriter(ResourcesFilePath))
                {
                    if (traducciones.Any())
                    {
                        foreach (var item in traducciones)
                        {
                            resxWriter.AddResource(item.Key, item.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Ocurrio un error al llenar el archivo de recursos: {0}", ex.Message);
            }

        }

        public static void ReadResources(Control.ControlCollection controls)
        {
            try
            {
                using (ResXResourceSet resxSet = new ResXResourceSet(ResourcesFilePath))
                {
                    foreach (DictionaryEntry item in resxSet)
                    {
                        controls[item.Key.ToString()].Text = item.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}
