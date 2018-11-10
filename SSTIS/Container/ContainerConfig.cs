using BE;
using BLL;
using BLL.Interfaces;
using DAL.Dao;
using DAL.Impl;
using DAL.Interfaces;
using DAL.Repositorios;
using SSTIS.Interfaces;

namespace SSTIS.Container
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SimpleInjector;

    public static class ContainerConfig
    {
        private static Container container;

        static ContainerConfig()
        {
            container = Bootstrap();
        }

        public static T Resolve<T>() where T : class
        {
            return container.GetInstance<T>();
        }

        private static Container Bootstrap()
        {
            // Create the container as usual.
            container = new Container();
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
            //Familia
            container.Register<IServicio<Familia>, ServicioFamilia>(Lifestyle.Singleton);
            container.Register<IRepository<Familia>, RepositorioFamilia>(Lifestyle.Singleton);
            container.Register<IDao<Familia>, FamiliaDao>(Lifestyle.Singleton);
            container.Register<IFamiliaDao, FamiliaDao>(Lifestyle.Singleton);
            container.Register<IServicioFamilia, ServicioFamilia>(Lifestyle.Singleton);
            container.Register<IRepositorioFamilia, RepositorioFamilia>(Lifestyle.Singleton);
            //Bitacora
            container.Register<IServicioBitacora, ServicioBitacora>(Lifestyle.Singleton);
            container.Register<IRepositorioBitacora, RepositorioBitacora>(Lifestyle.Singleton);
            container.Register<IBitacoraDao, BitacoraDao>(Lifestyle.Singleton);
            container.Register<IDigitoVerificador, DigitoVerificadorDao>(Lifestyle.Singleton);
            //Idioma
            container.Register<IServicioIdioma, ServicioIdioma>(Lifestyle.Singleton);
            container.Register<IRepositorioIdioma, RepositorioIdioma>(Lifestyle.Singleton);
            container.Register<IIdiomaDao, IdiomaDao>(Lifestyle.Singleton);
            //Patente
            container.Register<IServicioPatente, ServicioPatente>(Lifestyle.Singleton);
            container.Register<IRepositorioPatente, RepositorioPatente>(Lifestyle.Singleton);
            container.Register<IPatenteDao, PatenteDao>(Lifestyle.Singleton);
            //Formularios
            container.Register<INuevoUsuario, frmNuevoUsuario>(Lifestyle.Transient);
            container.Register<IABMUsuarios, frmABMUsuarios>(Lifestyle.Transient);
            container.Register<ILogin, frmLogin>(Lifestyle.Transient);
            container.Register<IPrincipal, frmPrincipal>(Lifestyle.Transient);
            container.Register<IRealizarCopiaSeguridad, frmRealizarCopiaSeguridad>(Lifestyle.Transient);
            container.Register<IRestaurarCopiaDeSeguridad, frmRestaurarCopiaDeSeguridad>(Lifestyle.Transient);
            container.Register<IBitacora, SSTIS.frmBitacora>(Lifestyle.Transient);
            container.Register<INuevaFamilia, frmNuevaFamilia>(Lifestyle.Transient);
            container.Register<IABMFamilia, frmABMFamilia>(Lifestyle.Transient);
            container.Register<IAdmPatenteFamilia, frmAdmFamiliaPatente>(Lifestyle.Transient);
            container.Register<IModificarFamilia, frmModificarFamiliaPopup>(Lifestyle.Transient);
            // Register your types, for instance
            container.Verify();
            return container;
        }
    }
}
