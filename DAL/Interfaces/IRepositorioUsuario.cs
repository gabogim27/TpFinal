using BE;

namespace DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepositorioUsuario
    {
        bool LogIn(string email, string contraseña);

        Usuario ObtenerUsuarioConEmail(string email);

        bool CambiarContraseña(Usuario usuario, string nuevaContraseña, bool primerLogin = false);

        bool ActualizarContIngresosIncorrectos(Guid usuarioId, int cantIngresosIncorrectos);

        bool BloquearUsuario(Guid idUsuario);

        bool DesBloquearUsuario(Guid idUsuario);

        List<Patente> ObtenerPatentesDeUsuario(Guid usuarioId);
    }
}
