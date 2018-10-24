﻿using System;
using System.Net.Mail;

namespace BLL
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
    }
}
