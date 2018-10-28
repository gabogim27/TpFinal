using SSTIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Dao;
using DAL.Impl;
using DAL.Interfaces;
using DAL.Repositorios;
using SimpleInjector;
using SSTIS.Interfaces;
using Bitacora = BE.Bitacora;

namespace SysAnalizer
{
    static class Program
    {

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = new Container();
            //Usuario
            container.Register<IServicio<Usuario>, ServicioUsuario>(Lifestyle.Singleton);
            container.Register<IRepository<Usuario>, RepositorioUsuario>(Lifestyle.Singleton);
            container.Register<IDao<Usuario>, UsuarioDao>(Lifestyle.Singleton);
            container.Register<IUsuarioDao, UsuarioDao>(Lifestyle.Singleton);
            container.Register<IRepositorioUsuario, RepositorioUsuario>(Lifestyle.Singleton);
            container.Register<IServicioUsuario, ServicioUsuario>(Lifestyle.Singleton);
            //Localidad
            container.Register<IServicio<Localidad>, ServicioLocalidad>(Lifestyle.Singleton);
            container.Register<IRepository<Localidad>, RepositorioLocalidad>(Lifestyle.Singleton);
            container.Register<IDao<Localidad>, LocalidadDao>(Lifestyle.Singleton);
            container.Register<ILocalidadDao, LocalidadDao>(Lifestyle.Singleton);
            container.Register<IRepositorioLocalidad, RepositorioLocalidad>(Lifestyle.Singleton);
            container.Register<IServicioLocalidad, ServicioLocalidad>(Lifestyle.Singleton);
            //Provincia
            container.Register<IServicio<Provincia>, ServicioProvincia>(Lifestyle.Singleton);
            container.Register<IRepository<Provincia>, RepositorioProvincia>(Lifestyle.Singleton);
            container.Register<IDao<Provincia>, ProvinciaDao>(Lifestyle.Singleton);
            //Domicilio
            container.Register<IServicio<Domicilio>, ServicioDomicilio>(Lifestyle.Singleton);
            container.Register<IRepository<Domicilio>, RepositorioDomicilio>(Lifestyle.Singleton);
            container.Register<IDao<Domicilio>, DomicilioDao>(Lifestyle.Singleton);
            //Contacto
            container.Register<IServicio<Contacto>, ServicioContacto>(Lifestyle.Singleton);
            container.Register<IRepository<Contacto>, RepositorioContacto>(Lifestyle.Singleton);
            container.Register<IDao<Contacto>, ContactoDao>(Lifestyle.Singleton);
            //Bitacora
            container.Register<IServicioBitacora, ServicioBitacora>(Lifestyle.Singleton);
            container.Register<IRepositorioBitacora, RepositorioBitacora>(Lifestyle.Singleton);
            container.Register<IBitacoraDao, BitacoraDao>(Lifestyle.Singleton);
            container.Register<IDigitoVerificador, DigitoVerificadorDao>(Lifestyle.Singleton);
            //Formularios
            container.Register<INuevoUsuario, NuevoUsuario>(Lifestyle.Transient);
            container.Register<IABMUsuarios, ABMUsuarios>(Lifestyle.Transient);
            container.Register<ILogin, Login>(Lifestyle.Transient);
            container.Register<IPrincipal, Principal>(Lifestyle.Transient);
            container.Register<IRealizarCopiaSeguridad, RealizarCopiaSeguridad>(Lifestyle.Transient);
            container.Register<IRestaurarCopiaDeSeguridad, RestaurarCopiaDeSeguridad>(Lifestyle.Transient);
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container
                .GetInstance<ABMUsuarios>()); //    new ABMUsuarios(new Repository<Usuario>(new UsuarioDao())));
        }
    }
}
