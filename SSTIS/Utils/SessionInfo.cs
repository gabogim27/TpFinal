using BE;
using BLL;
using BLL.Interfaces;
using SSTIS.Interfaces;

namespace SSTIS.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class SessionInfo : ISessionInfo
    {
        public IServicioFamilia ServicioFamiliaImplementor;
        public IServicioPatente ServicioPatente;
        public IServicioUsuario ServicioUsuarioImplementor;

        public SessionInfo(IServicioFamilia ServicioFamiliaImplementor, 
            IServicioPatente ServicioPatente, IServicioUsuario ServicioUsuarioImplementor)
        {
            this.ServicioUsuarioImplementor = ServicioUsuarioImplementor;
            this.ServicioPatente = ServicioPatente;
            this.ServicioFamiliaImplementor = ServicioFamiliaImplementor;
        }
        public void GuardarDatosSesionUsuario(Usuario usuario)
        {
            usuario.Familia = new List<Familia>();

            var famIds = ServicioFamiliaImplementor.ObtenerIdsFamiliasPorUsuario(usuario.IdUsuario);

            foreach (var id in famIds)
            {
                usuario.Familia.Add(new Familia() { IdFamilia = id, Descripcion = ServicioFamiliaImplementor.ObtenerDescripcionFamiliaPorId(id) });
            }

            LoginInfo.Usuario.Familia = usuario.Familia;
        }

        public Usuario ObtenerPermisosUsuario()
        {
            var patentes = new List<Patente>();

            patentes.AddRange(ServicioUsuarioImplementor.ObtenerPatentesDeUsuario(LoginInfo.Usuario.IdUsuario));

            patentes.AddRange(ServicioFamiliaImplementor.ObtenerPatentesFamilia(LoginInfo.Usuario.Familia.Select(x => x.IdFamilia).ToList()));

            patentes = patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();

            LoginInfo.Usuario.Patentes = patentes;

            return LoginInfo.Usuario;
        }

        public List<Patente> ObtenerPermisosFormularios()
        {
            return ServicioPatente.ObtenerPermisosFormularios();
        }

        public List<Patente> ObtenerPermisosFormulario(Guid formId)
        {
            return ServicioPatente.ObtenerPermisosFormulario(formId);
        }
    }
}
