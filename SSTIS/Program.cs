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
using DAL.Impl;
using DAL.Interfaces;
using DAL.Repositorios;
using SimpleInjector;
using SSTIS.Interfaces;

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
            container.Register<IServicio<Usuario>, ServicioUsuario>(Lifestyle.Singleton);
            container.Register<IRepository<Usuario>, RepositorioUsuario>(Lifestyle.Singleton);
            container.Register<IDao<Usuario>, UsuarioDao>(Lifestyle.Singleton);
            container.Register<INuevoUsuario, NuevoUsuario>(Lifestyle.Singleton);
            container.Register<IABMUsuarios, ABMUsuarios>(Lifestyle.Singleton);
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container
                .GetInstance<ABMUsuarios>()); //    new ABMUsuarios(new Repository<Usuario>(new UsuarioDao())));
        }
    }
}
