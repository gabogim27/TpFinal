using BE;

namespace DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUsuarioDao
    {
        bool LogIn(string email, string contraseña);

        bool ReactivarUsuario(BE.Usuario ObjDel);

        bool CambiarPassword(Usuario usuario, string nuevaContraseña, bool primerLogin);

        Usuario ObtenerUsuarioConEmail(string email);

        bool CambiarContraseña(Usuario usuario, string nuevaContraseña, bool primerLogin = false);

        bool ActualizarContIngresosIncorrectos(Guid usuarioId, int cantIngresosIncorrectos);

        bool BloquearUsuario(Guid idUsuario);

        bool DesBloquearUsuario(Guid idUsuario);

        List<Patente> ObtenerPatentesDeUsuario(Guid usuarioId);
    }
}
