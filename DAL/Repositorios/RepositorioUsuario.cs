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

    public class RepositorioUsuario : IRepository<Usuario>
    {
        public IDao<Usuario> UsuarioDao { get; }

        public RepositorioUsuario(IDao<Usuario> usuarioDao)
        {
            this.UsuarioDao = usuarioDao ?? throw new ArgumentNullException(nameof(usuarioDao));
        }
        public bool Create(Usuario ObjAlta)
        {
            return UsuarioDao.Create(ObjAlta);
        }

        public Usuario GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Delete(Usuario ObjDel)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario ObjUpd)
        {
            throw new NotImplementedException();
        }
    }
}
