using System.Data;
using System.Linq;
using BLL.Interfaces;
using DAL;
using TimeSpan = System.TimeSpan;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using BE;   
    using DAL.Impl;

    public class ServicioUsuario : IServicio<Usuario>
    {
        public IRepository<Usuario> RepositorioUsuario { get; }

        public ServicioUsuario(IRepository<Usuario> repositorioUsuario)
        {
            this.RepositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }
        public bool Create(Usuario entity)
        {
            return RepositorioUsuario.Create(entity);
        }

        public Usuario GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
