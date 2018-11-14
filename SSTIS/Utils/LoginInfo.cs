using System.IO;
using BE;

namespace SSTIS.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class LoginInfo
    {
        public static Usuario Usuario = new Usuario();
        public static IdiomaUsuario LenguajeSeleccionado = new IdiomaUsuario();
        public static IDictionary<string, string> Traducciones = new Dictionary<string, string>();
        
        public static readonly string ResourcesFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\\\Resources\\\\SpanishResources.resx";
    }
}
