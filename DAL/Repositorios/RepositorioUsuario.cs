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

        public RepositorioUsuario(IDao<Usuario> usuarioDao, IUsuarioDao UsuarioDaoImplementor)
        {
            this.UsuarioDao = usuarioDao ?? throw new ArgumentNullException(nameof(usuarioDao));
            this.UsuarioDaoImplementor = UsuarioDaoImplementor;
        }
        public bool Create(Usuario ObjAlta)
        {
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
    }
}
