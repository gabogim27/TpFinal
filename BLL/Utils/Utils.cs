using System;
using System.Net.Mail;

namespace BLL.Utils
{
    public static class Utils
    {
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

        public enum LogLevel
        {
            Alta,
            Media,
            Baja
        }
    }
}
