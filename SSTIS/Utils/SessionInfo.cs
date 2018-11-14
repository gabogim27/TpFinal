using BE;
using BLL;
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

        public SessionInfo(IServicioFamilia ServicioFamiliaImplementor)
        {
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
    }
}
