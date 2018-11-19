using BE;
using DAL.Impl;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioUsuario : IRepository<Usuario>, IRepositorioUsuario
    {
        public IDao<Usuario> UsuarioDao { get; }
        public IUsuarioDao UsuarioDaoImplementor { get; set; }
        public IDigitoVerificador DigitoVerificador;

        public RepositorioUsuario(IDao<Usuario> usuarioDao, IUsuarioDao UsuarioDaoImplementor,
            IDigitoVerificador DigitoVerificador)
        {
            this.UsuarioDao = usuarioDao ?? throw new ArgumentNullException(nameof(usuarioDao));
            this.UsuarioDaoImplementor = UsuarioDaoImplementor;
            this.DigitoVerificador = DigitoVerificador;
        }
        public bool Create(Usuario ObjAlta)
        {
            int dvh = DigitoVerificador.CalcularDVHorizontal(new List<string>()
            {
                ObjAlta.IdUsuario.ToString(), ObjAlta.Email, ObjAlta.Domicilio.IdDomicilio.ToString(),
                ObjAlta.Contacto.IdContacto.ToString() }, new List<int>() { Convert.ToInt32(ObjAlta.Estado) });
            ObjAlta.Dvh = dvh;
            return UsuarioDao.Create(ObjAlta);
        }

        public Usuario GetById(Guid id)
        {
            return UsuarioDao.GetById(id);
        }

        public List<Usuario> Retrive()
        {
            return UsuarioDao.Retrive();
        }

        public bool Delete(Usuario ObjDel)
        {
            return UsuarioDao.Delete(ObjDel);
        }

        public bool Update(Usuario ObjUpd)
        {
            return UsuarioDao.Update(ObjUpd);
        }

        public bool LogIn(string email, string contraseña)
        {
            return UsuarioDaoImplementor.LogIn(email, contraseña);
        }

        public Usuario ObtenerUsuarioConEmail(string email)
        {
            return UsuarioDaoImplementor.ObtenerUsuarioConEmail(email);
        }

        public bool CambiarContraseña(Usuario usuario, string nuevaContraseña, bool primerLogin = false)
        {
            return UsuarioDaoImplementor.CambiarContraseña(usuario, nuevaContraseña, primerLogin);
        }

        public bool ActualizarContIngresosIncorrectos(Guid usuarioId, int cantIngresosIncorrectos)
        {
            return UsuarioDaoImplementor.ActualizarContIngresosIncorrectos(usuarioId, cantIngresosIncorrectos);
        }

        public bool BloquearUsuario(Guid idUsuario)
        {
            return UsuarioDaoImplementor.BloquearUsuario(idUsuario);
        }

        public bool DesBloquearUsuario(Guid idUsuario)
        {
            return UsuarioDaoImplementor.DesBloquearUsuario(idUsuario);
        }

        public List<Patente> ObtenerPatentesDeUsuario(Guid usuarioId)
        {
            return UsuarioDaoImplementor.ObtenerPatentesDeUsuario(usuarioId);
        }
    }
}
