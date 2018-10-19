using SSTIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using DAL;
using DAL.Impl;
using DAL.Interfaces;
using SimpleInjector;

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
            container.Register<IRepository<Usuario>, Repository<Usuario>>();
            container.Register<IDao<Usuario>, UsuarioDao>();
            //container.RegisterInstance(container);
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container
                .GetInstance<ABMUsuarios>()); //    new ABMUsuarios(new Repository<Usuario>(new UsuarioDao())));
        }
    }
}
