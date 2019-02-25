using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Xml;

namespace SSTIS.Encryption
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class EncryptionHelper
    {
        public static readonly string AppConfigFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName + "\\App.config";
        public static string _connectionString = ConfigurationManager.ConnectionStrings["SistemaTISConnectionString"].ToString();

        public static string EncriptarASCII(string input)
        {
            Byte[] IV = ASCIIEncoding.ASCII.GetBytes("qualityi");
            Byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5");
            Byte[] Buffer = Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = EncryptionKey;
            des.IV = IV;
            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        public static string DesencriptarASCII(string input)
        {
            Byte[] IV = ASCIIEncoding.ASCII.GetBytes("qualityi"); // La clave debe ser de 8 caracteres
            Byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5"); // No se puede alterar la cantidad de caracteres pero si la clave
            Byte[] Buffer = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = EncryptionKey;
            des.IV = IV;
            return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        public static void EncriptarConnectionString()
        {
            var connString = _connectionString;
            var encriptedConnString = EncryptionHelper.EncriptarASCII(connString);

            XmlDocument doc = new XmlDocument();
            doc.Load(AppConfigFilePath);
            XmlNodeList xmlnode;
            xmlnode = doc.GetElementsByTagName("connectionStrings");
            foreach (XmlNode nodo in xmlnode)
            {
                nodo.FirstChild.Attributes[1].InnerText = encriptedConnString;
            }

            doc.Save(AppConfigFilePath);
        }

        public static string DesEncriptarConnectionString()
        {
            var connString = _connectionString;
            var decryptedConnString = EncryptionHelper.DesencriptarASCII(connString);

            XmlDocument doc = new XmlDocument();
            doc.Load(AppConfigFilePath);
            XmlNodeList xmlnode;
            xmlnode = doc.GetElementsByTagName("connectionStrings");
            foreach (XmlNode nodo in xmlnode)
            {
                nodo.FirstChild.Attributes[1].InnerText = decryptedConnString;
            }

            //doc.Save(AppConfigFilePath);
            return decryptedConnString;
        }
    }
}
