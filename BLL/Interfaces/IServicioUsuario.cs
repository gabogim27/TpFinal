using BE;

namespace BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IServicioUsuario
    {
        bool LogIn(string email, string contraseña);
        bool ReactivarUsuario(BE.Usuario ObjDel);
        Usuario ObtenerUsuarioConEmail(string email);
        bool ValidarEmail(string email);
        bool CambiarContraseña(Usuario usuario, string nuevaContraseña, bool primerLogin = false);
        List<Patente> ObtenerPatentesDeUsuario(Guid usuarioId);
        bool BloquearUsuario(Guid idUsuario);
        bool DesbloquearUsuario(Guid idUsuario);
    }
}
