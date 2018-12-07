using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BLL;
using BLL.Interfaces;
using Castle.Components.DictionaryAdapter;
using DAL.Impl;
using DAL.Interfaces;
using DAL.Repositorios;
using Moq;
using NUnit.Framework;
using SimpleInjector;
using SSTIS;
using SSTIS.Container;

namespace Test
{
    [TestFixture]
    public class UsuarioTest
    {
        private List<Guid> todasLasPatentes = new List<Guid>() { new Guid("4E6AA717-AC41-426B-B158-0902EE789B4D") , new Guid("D0DDE1CE-453A-480D-938A-28D0004ECCDB"),
            new Guid("99652D0B-F254-4E1A-9D44-4DF76D879A4D"), new Guid("52D962DE-D5F0-4BD6-BF14-7D4D5753795A"), new Guid("26C8332D-F968-4EA1-8447-C9132703A426"),
            new Guid("00C9BF76-1309-4801-B1C4-D3FFBC1BDAA4")};
        private IRepositorioUsuario repositorioUsuarioImplementor;
        private IRepository<Usuario> repositorioUsuario;
        private IRepositorioPatente repositorioPatente;
        private IRepositorioFamilia repositorioFamiliaImplementor;
        private IDao<Familia> repositorioFamilia;
        public Usuario usuario { get; set; } = new Usuario();
        //public SimpleInjector.Container simpleInyectorContainer = new Container();

        [SetUp]
        public void Setup()
        {
            CrearInstancias();
        }

        private void CrearInstancias()
        {
            repositorioUsuarioImplementor = new RepositorioUsuario(ContainerConfig.Resolve<IDao<Usuario>>(), ContainerConfig.Resolve<IUsuarioDao>(),
                ContainerConfig.Resolve<IDigitoVerificador>());
            repositorioUsuario = new Repository<Usuario>(ContainerConfig.Resolve<IDao<Usuario>>());
            repositorioPatente = new RepositorioPatente(ContainerConfig.Resolve<IPatenteDao>());
            repositorioFamiliaImplementor = new RepositorioFamilia(ContainerConfig.Resolve<IDao<Familia>>(), ContainerConfig.Resolve<IFamiliaDao>());
            repositorioFamilia = ContainerConfig.Resolve<IDao<Familia>>();

            usuario = repositorioUsuario.Retrive().FirstOrDefault(u => u.Nombre == "Nunit");
            usuario.Patentes = new List<Patente>();
            usuario.Familia = new List<Familia>();
        }

        [Test]
        public void Reinicio()
        {
            repositorioUsuario.Delete(usuario);
            repositorioPatente.BorrarListaPatentesUsuario(todasLasPatentes, usuario.IdUsuario);
        }

        [Test]
        public void CreateUsuarioShouldReturnOk()
        {
            var contacto = new Contacto();
            contacto.IdContacto = new Guid("76D4127D-92C9-465F-9449-A89F6A06C680");
            var domicilio = new Domicilio();
            domicilio.IdDomicilio = new Guid("6B23FD3C-50E0-4D75-9948-D86330F3EF44");
            repositorioUsuario.Create(new Usuario { IdUsuario = Guid.NewGuid() ,Nombre = "Nunit", Apellido = "Nunit", ContraseñaEncriptada = "123456", Email = "Nunit", Domicilio = domicilio, Familia = new List<Familia>(), Patentes = new List<Patente>(), PrimerLogin = true, IdIdioma = new Guid("632302C5-266A-440D-9F39-6DC6DDEBAACF"), CantIngresosFallidos = 0, Estado = true, Contacto = contacto});
            Assert.AreEqual(true, repositorioUsuario.Retrive().Exists(usuario => usuario.Nombre == "Nunit"));
        }

        [Test]
        public void DeleteAllUsersShouldNotReturnOk()
        {
            //Assert.AreEqual(false, repositorioPatente.CheckeoDePatentesParaBorrar(usuario, false, false, null, true));
        }

        [Test]
        public void AssignAllPatentesToUserShouldReturnOk()
        {
            repositorioPatente.GuardarPatentesUsuario(todasLasPatentes, usuario.IdUsuario);
            Assert.AreEqual(todasLasPatentes.Count, repositorioPatente.ConsultarUsuarioPatente(usuario.IdUsuario).Count);
        }

        [Test]
        public void DeleteAllOtherUsersShouldReturnOK()
        {
            //Assert.AreEqual(true, repositorioPatente.CheckeoDePatentesParaBorrar(usuario, false, false, null, true));
        }

        [Test]
        public void DeleteAllFamiliesShouldReturnOK()
        {
            var familias = repositorioFamilia.Retrive();
            var usuarios = new List<Usuario>();

            foreach (var idFamilia in familias.Select(x => x.IdFamilia))
            {
                usuarios.AddRange(repositorioFamiliaImplementor.ObtenerUsuariosPorFamilia(idFamilia));
            }

            //usuarios = usuarios.Where(x => x.IdUsuario);
            //var cantFamilias = 

            //foreach (var usuario in usuarios)
            //{
            //    if (patenteBLL.CheckeoDePatentesParaBorrar(usuario, true))
            //    {
            //        returnValue = true;
            //    }
                
            //}
        }
    }
}
