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
    using DAL.Impl;
    using BE;
    using DAL.Utils;

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

        public bool Create(BE.Usuario ObjAlta)
        {
            Random random = new Random();
            string nuevoPass = random.Next().ToString();
            var contraseñaEncriptada = MD5.ComputeMD5Hash(ObjAlta.Password = nuevoPass);

            //Damos de alta el domicilio del usuario
            var objDomicilio = new BE.Domicilio();
            objDomicilio.IdDomicilio = Guid.NewGuid();
            objDomicilio.Direccion = ObjAlta.Domicilio.Direccion;
            objDomicilio.CodPostal = "1665";//agregar esto en la UI
            var localidad = Impl.Localidad.Getinstancia().GetById(ObjAlta.Domicilio.Localidad.IdLocalidad);
            objDomicilio.Localidad = localidad;

            Impl.Domicilio.GetInstancia().Create(objDomicilio);
            //Damos de alta el contacto del usuario
            var objContacto = new BE.Contacto();
            objContacto.Id = Guid.NewGuid();
            objContacto.Telefono = ObjAlta.Contacto.Telefono;
            objContacto.Celular = ObjAlta.Contacto.Celular;
            DAL.Impl.Contacto.GetInstancia().Create(objContacto);

            var queryString = string.Format("INSERT INTO dbo.Usuario(IdUsuario, Nombre, Apellido, Password, Email, " +
                "CantLoginsFallidos, Estado, IdDomicilio, IdContacto, IdIdioma, PrimerLogin) values " +
                "('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}','{9}',{10})",
                ObjAlta.Id = Guid.NewGuid(),
                ObjAlta.Nombre,
                ObjAlta.Apellido,
                contraseñaEncriptada,
                ObjAlta.Email,
                ObjAlta.CantIngresosFallidos = 0,
                Convert.ToByte(ObjAlta.Estado = true),              
                objDomicilio.IdDomicilio,
                objContacto.Id,
                ObjAlta.IdIdioma = new Guid("632302C5-266A-440D-9F39-6DC6DDEBAACF"),//cambiar el id este, hacerlo bien                
                Convert.ToByte(ObjAlta.PrimerLogin)
                );

            var returnValue = false;

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Execute(queryString);
                   
                    return !returnValue;
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

            using (IDbConnection connection = SqlUtils.Connection())
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

            using (SqlConnection connection = SqlUtils.Connection())
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

        public BE.Usuario GetById(Guid id)
        {
            throw new NotImplementedException();
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
