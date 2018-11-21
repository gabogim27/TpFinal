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
using SSTIS.Container;
using SSTIS.Interfaces;
using SSTIS.Utils;
using Bitacora = BE.Bitacora;

namespace SSTIS
{
    static class Program
    {
        public static SimpleInjector.Container simpleInyectorContainer;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            simpleInyectorContainer = new SimpleInjector.Container();
            //Usuario
            simpleInyectorContainer.Register<IServicio<Usuario>, ServicioUsuario>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepository<Usuario>, RepositorioUsuario>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IDao<Usuario>, UsuarioDao>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IUsuarioDao, UsuarioDao>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepositorioUsuario, RepositorioUsuario>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IServicioUsuario, ServicioUsuario>(Lifestyle.Singleton);
            //Localidad
            simpleInyectorContainer.Register<IServicio<Localidad>, ServicioLocalidad>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepository<Localidad>, RepositorioLocalidad>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IDao<Localidad>, LocalidadDao>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<ILocalidadDao, LocalidadDao>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepositorioLocalidad, RepositorioLocalidad>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IServicioLocalidad, ServicioLocalidad>(Lifestyle.Singleton);
            //Provincia
            simpleInyectorContainer.Register<IServicio<Provincia>, ServicioProvincia>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepository<Provincia>, RepositorioProvincia>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IDao<Provincia>, ProvinciaDao>(Lifestyle.Singleton);
            //Domicilio
            simpleInyectorContainer.Register<IServicio<Domicilio>, ServicioDomicilio>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepository<Domicilio>, RepositorioDomicilio>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IDao<Domicilio>, DomicilioDao>(Lifestyle.Singleton);
            //Contacto
            simpleInyectorContainer.Register<IServicio<Contacto>, ServicioContacto>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepository<Contacto>, RepositorioContacto>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IDao<Contacto>, ContactoDao>(Lifestyle.Singleton);
            //Familia
            simpleInyectorContainer.Register<IServicio<Familia>, ServicioFamilia>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepository<Familia>, RepositorioFamilia>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IDao<Familia>, FamiliaDao>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IFamiliaDao, FamiliaDao>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IServicioFamilia, ServicioFamilia>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepositorioFamilia, RepositorioFamilia>(Lifestyle.Singleton);
            //Bitacora
            simpleInyectorContainer.Register<IServicioBitacora, ServicioBitacora>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepositorioBitacora, RepositorioBitacora>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IBitacoraDao, BitacoraDao>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IDigitoVerificador, DigitoVerificadorDao>(Lifestyle.Singleton);
            //Idioma
            simpleInyectorContainer.Register<IServicioIdioma, ServicioIdioma>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepositorioIdioma, RepositorioIdioma>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IIdiomaDao, IdiomaDao>(Lifestyle.Singleton);
            //Patente
            simpleInyectorContainer.Register<IServicioPatente, ServicioPatente>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRepositorioPatente, RepositorioPatente>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IPatenteDao, PatenteDao>(Lifestyle.Singleton);
            //Formularios
            simpleInyectorContainer.Register<INuevoUsuario, frmNuevoUsuario>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IABMUsuarios, frmABMUsuarios>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<ILogin, frmLogin>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IPrincipal, frmPrincipal>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRealizarCopiaSeguridad, frmRealizarCopiaSeguridad>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IRestaurarCopiaDeSeguridad, frmRestaurarCopiaDeSeguridad>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IBitacora, SSTIS.frmBitacora>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<INuevaFamilia, frmNuevaFamilia>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IABMFamilia, frmABMFamilia>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IAdmPatenteFamilia, frmAdmFamiliaPatente>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IModificarFamilia, frmModificarFamiliaPopup>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IAdminFamiliaUsuario, frmAdminFamiliaUsuario>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<IAdminPatenteUsuario, frmAdministracionPatenteUsuario>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<ISessionInfo, SessionInfo>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<ICambiarIdioma, frmCambiarIdioma>(Lifestyle.Singleton);
            simpleInyectorContainer.Register<ICambiarContraseña, frmCambiarContraseña>(Lifestyle.Singleton);
            //ContainerConfig.Bootstrap();
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(simpleInyectorContainer
                .GetInstance<SSTIS.frmLogin>()); //    new ABMUsuarios(new Repository<Usuario>(new UsuarioDao())));
        }
    }
}
