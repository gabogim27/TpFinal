using System.Net.Mail;

namespace SSTIS.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ControlsUtils
    {
        public static bool ValidarControles(string nombre, string apellido, string domicilio, string cp, string celular, string telFijo)
        {
            if (!string.IsNullOrEmpty(nombre.Trim()) && !string.IsNullOrEmpty(apellido.Trim()) &&
                !string.IsNullOrEmpty(domicilio.Trim()) && !string.IsNullOrEmpty(cp.Trim()) &&
                !string.IsNullOrEmpty(celular.Trim()) && !string.IsNullOrEmpty(telFijo.Trim()))
                return true;
            return false;
        }

        public static bool ValidarEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
