using System.Data;
using System.IO;
using System.Linq;
using EasyEncryption;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using log4net;
using BLL.Utils;
using TimeSpan = System.TimeSpan;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using BE;
    using DAL.Impl;

    public class ServicioUsuario : IServicio<Usuario>, IServicioUsuario
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ServicioUsuario));

        public IRepository<Usuario> RepositorioUsuario;
        public IRepository<Localidad> RepositorioLocalidad;
        public IRepository<Provincia> RepositorioProvincia;
        public IRepository<Domicilio> RepositorioDomicilio;
        public IRepository<Contacto> RepositorioContacto;
        public IRepositorioBitacora RepositorioBitacora;
        public IRepositorioUsuario RepositorioUsuarioImplementor;

        public ServicioUsuario(IRepository<Usuario> repositorioUsuario,
            IRepository<Localidad> repositorioLocalidad, IRepository<Domicilio> repositorioDomicilio,
            IRepository<Contacto> repositorioContacto, IRepositorioBitacora repositorioBitacora,
            IRepositorioUsuario repositorioUsuarioImplementor, IRepository<Provincia> repositorioProvincia)
        {
            this.RepositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            this.RepositorioLocalidad = repositorioLocalidad;
            this.RepositorioDomicilio = repositorioDomicilio;
            this.RepositorioContacto = repositorioContacto;
            this.RepositorioBitacora = repositorioBitacora;
            this.RepositorioUsuarioImplementor = repositorioUsuarioImplementor;
            this.RepositorioProvincia = repositorioProvincia;
        }
        public bool Create(Usuario entity)
        {
            //Llamar repositorio localidad
            Random random = new Random();
            var nuevoPass = random.Next();
            //Guardarlo en un archivo en el C:
            SavePasswordOnFile(nuevoPass, entity.Email);

            //entity.ContraseñaEncriptada = MD5.ComputeMD5Hash(entity.Password = nuevoPass);
            entity.ContraseñaEncriptada = nuevoPass.ToString();
            //Damos de alta el domicilio del usuario
            var objDomicilio = new BE.Domicilio();
            objDomicilio.IdDomicilio = Guid.NewGuid();
            objDomicilio.Direccion = entity.Domicilio.Direccion;
            objDomicilio.CodPostal = entity.Domicilio.CodPostal;
            //Retrieve Localidad
            var localidad = RepositorioLocalidad.GetById(entity.Domicilio.Localidad.IdLocalidad);
            objDomicilio.Localidad = localidad;
            //Retrieve Provincia
            var provincia = RepositorioProvincia.GetById(entity.Domicilio.Provincia.IdProvincia);
            objDomicilio.Provincia = provincia;
            //Create domicilio
            RepositorioDomicilio.Create(objDomicilio);
            //Damos de alta el contacto del usuario
            var objContacto = new BE.Contacto();
            objContacto.IdContacto = Guid.NewGuid();
            objContacto.Telefono = entity.Contacto.Telefono;
            objContacto.Celular = entity.Contacto.Celular;
            RepositorioContacto.Create(objContacto);
            //Update ids
            entity.Domicilio.IdDomicilio = objDomicilio.IdDomicilio;
            entity.Contacto.IdContacto = objContacto.IdContacto;
            return RepositorioUsuario.Create(entity);
        }

        public void SavePasswordOnFile(int nuevoPass, string usuario)
        {
            try
            {
                var path = "C:\\SistemaTIS";

                Directory.CreateDirectory(path);

                using (var tw = new StreamWriter(path + "\\" + usuario + "_Aleatory_Password.txt", true))
                {
                    tw.WriteLine(nuevoPass.ToString());
                }
            }
            catch (Exception ex)
            {
                var mensaje = string.Format("Ocurrio un error al guardar la password en el .txt. Error: {0}", ex.Message);

                RepositorioBitacora.RegistrarEnBitacora(Convert.ToString(Utils.Utils.LogLevel.Alta), mensaje);
            }
        }

        public Usuario GetById(Guid id)
        {
            return RepositorioUsuario.GetById(id);
        }

        public List<Usuario> Retrive()
        {
            return RepositorioUsuario.Retrive();
        }

        public bool Delete(Usuario entity)
        {
            return RepositorioUsuario.Delete(entity);
        }

        public bool Update(Usuario entity)
        {
            if (RepositorioUsuario.Update(entity))
            {
                //Actualizamos por ultimo los datos del contacto
                return RepositorioContacto.Update(entity.Contacto);
            }

            return false;
        }

        public bool LogIn(string email, string contraseña)
        {
            Usuario usuario = null;
            try
            {
                var ingresa = RepositorioUsuarioImplementor.LogIn(email, contraseña);

                usuario = RepositorioUsuarioImplementor.ObtenerUsuarioConEmail(email);
                if (usuario == null)
                    return false;

                var contIngresos = usuario.CantIngresosFallidos;

                if (ingresa)
                {
                    var mensaje = string.Format("Usuario: {0} logueado correctamente.", usuario.Email);
                    RepositorioBitacora.RegistrarEnBitacora(Convert.ToString(Utils.Utils.LogLevel.Alta), mensaje, usuario);
                    return ingresa;
                }

                //if (!ingresa)
                //{
                //    //Actualizar el contador de ingresos fallidos
                //    contIngresos++;
                //    RepositorioUsuarioImplementor.ActualizarContIngresosIncorrectos(usuario.IdUsuario, contIngresos);
                //}

                if (usuario.CantIngresosFallidos < 3)
                {
                    RepositorioBitacora.RegistrarEnBitacora(Utils.Utils.LogLevel.Alta.ToString(),
                        string.Format("Login Fallido para el usuario: " + "'{0}'", usuario.Email), usuario);
                }
                else
                {
                    RepositorioBitacora.RegistrarEnBitacora(Utils.Utils.LogLevel.Alta.ToString(), string.Format("La cuenta del usuario" +
                                                                                                                "'{0}' ha sido bloqueada tras 3 intento de login fallido.", usuario.Email), usuario);
                }

                return ingresa;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Hubo un error al loguear el usuario: {0}", usuario.IdUsuario);
                return false;
            }
        }

        public bool ReactivarUsuario(Usuario ObjDel)
        {
            return RepositorioUsuarioImplementor.ReactivarUsuario(ObjDel);
        }

        public Usuario ObtenerUsuarioConEmail(string email)
        {
            return RepositorioUsuarioImplementor.ObtenerUsuarioConEmail(email);
        }

        public bool ValidarEmail(string email)
        {
            return Utils.Utils.ValidarEmail(email);
        }

        public bool CambiarContraseña(Usuario usuario, string nuevaContraseña, bool primerLogin = false)
        {
            return RepositorioUsuarioImplementor.CambiarContraseña(usuario, nuevaContraseña, primerLogin);
        }

        public List<Patente> ObtenerPatentesDeUsuario(Guid usuarioId)
        {
            return RepositorioUsuarioImplementor.ObtenerPatentesDeUsuario(usuarioId);
        }

        public bool BloquearUsuario(Guid idUsuario)
        {
            return RepositorioUsuarioImplementor.BloquearUsuario(idUsuario);
        }

        public bool DesbloquearUsuario(Guid idUsuario)
        {
            return RepositorioUsuarioImplementor.DesBloquearUsuario(idUsuario);
        }
    }
}
