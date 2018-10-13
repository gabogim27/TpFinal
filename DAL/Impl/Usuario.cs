namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using EasyEncryption;
    using Dapper;

    public class Usuario : BE.ICRUD<BE.Usuario>
    {
        private static Usuario instancia;

        SqlCommand comm = new SqlCommand();

        private Usuario()
        {
        }

        public static Usuario Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Usuario();
            }
            return instancia;
        }

        public static SqlConnection Connection()
        {
            var conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=EZE1-LHP-B01637;Initial Catalog=SistemaTIS;Integrated Security=True";
            return conn;
        }


        public bool Create(BE.Usuario ObjAlta)
        {
            Random random = new Random();
            string nuevoPass = random.Next().ToString();
            var contraseñaEncriptada = MD5.ComputeMD5Hash(ObjAlta.Password = nuevoPass);


            var queryString = string.Format("INSERT INTO dbo.Usuario(Id, Nombre, Apellido, Password, Email, CantLoginsFallidos, Estado, IdDomicilio, IdContacto, IdIdioma, PrimerLogin) values ({0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10})",
                ObjAlta.Id = Guid.NewGuid(),
                ObjAlta.Nombre,
                ObjAlta.Apellido,
                contraseñaEncriptada,
                ObjAlta.Email,
                ObjAlta.CantIngresosFallidos,
                ObjAlta.Estado = true,              
                ObjAlta.CantIngresosFallidos = 0,
                ObjAlta.Domicilio.IdDomicilio,
                ObjAlta.IdIdioma,
                ObjAlta.Contacto.Id,
                ObjAlta.IdIdioma,
                ObjAlta.PrimerLogin
                );

            bool returnValue = false;

            using (IDbConnection connection = Connection())
            {
                try
                {
                    connection.Execute(queryString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return returnValue;
        }

        public List<BE.Usuario> Retrive()
        {
            var usuario = new BE.Usuario();
            var queryString = "SELECT * FROM dbo.Usuario;";
            var comm = new SqlCommand();

            using (IDbConnection connection = Connection())
            {
                try
                {

                    return (List<BE.Usuario>)connection.Query<BE.Usuario>(queryString);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Delete(BE.Usuario ObjDel)
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Usuario ObjUpd)
        {
            throw new NotImplementedException();
        }

        public bool LogIn(string email, string contraseña)
        {
            BE.Usuario usu = ObtenerUsuarioConEmail(email);
            if (!usu.PrimerLogin)
            {
                var cIngresoInc = usu.CantIngresosFallidos;

                if (cIngresoInc < 3)
                {
                    //string contEncriptada = Encriptar(contraseña);
                    //bool ingresa = ValidarContraseña(usu, contEncriptada);
                    //if (!ingresa)
                    //{
                    //    cIngresoInc++;
                    //    //AumentarIngresos();
                    //}
                }
                return false;
            }
            return true;
        }

        private bool ValidarContraseña(BE.Usuario usuario, string contEncriptada)
        {
            if (usuario.Password == contEncriptada)
            {
                return true;
            }

            return false;
        }

        private BE.Usuario ObtenerUsuarioConEmail(string email)
        {
            var usuario = new BE.Usuario();
            var queryString = string.Format("SELECT * FROM dbo.Usuario WHERE Email = '{0}'", email);
            var comm = new SqlCommand();

            using (SqlConnection connection = Connection())
            {
                comm.CommandText = queryString;
                comm.Connection = connection;
                comm.CommandType = CommandType.Text;

                var Da = new SqlDataAdapter();
                Da.SelectCommand = comm;

                DataTable Dt = new DataTable();

                Da.Fill(Dt);

                foreach (DataRow dr in Dt.Rows)
                {
                    usuario.Nombre = Convert.ToString(dr["Nombre"]);
                    usuario.Apellido = Convert.ToString(dr["Apellido"]);
                    usuario.Password = Convert.ToString(dr["Password"]);
                    usuario.Email = Convert.ToString(dr["Email"]);
                    usuario.Contacto.Id = Guid.Parse(dr["IdContacto"].ToString());
                    usuario.CantIngresosFallidos = Convert.ToInt32(dr["CantIngresosFallidos"]);
                    usuario.Estado = Convert.ToBoolean(dr["Estado"]);
                    usuario.PrimerLogin = Convert.ToBoolean(dr["PrimerLogin"]);
                    usuario.IdIdioma = Guid.Parse(dr["IdIdioma"].ToString());
                    usuario.Domicilio.IdDomicilio = Guid.Parse(dr["IdDomicilio"].ToString());
                }
                return usuario;
            }
        }

        //public string Encriptar(string contraseña)
        //{
        //    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        //    md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(contraseña));
        //    byte[] encriptado = md5.Hash;
        //    StringBuilder str = new StringBuilder();
        //    for (int i = 1; i < encriptado.Length; i++)
        //    {
        //        str.Append(encriptado[i].ToString("x2"));
        //    }
        //    return str.ToString();
        //}
    }
}
