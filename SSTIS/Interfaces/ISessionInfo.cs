using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace SSTIS.Interfaces
{
    public interface ISessionInfo
    {
        void GuardarDatosSesionUsuario(Usuario usuario);

        Usuario ObtenerPermisosUsuario();

        List<Patente> ObtenerPermisosFormularios();

        List<Patente> ObtenerPermisosFormulario(Guid formId);
    }
}
