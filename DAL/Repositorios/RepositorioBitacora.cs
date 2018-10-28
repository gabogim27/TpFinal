using BE;
using DAL.Dao;
using DAL.Interfaces;
using log4net;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioBitacora : IRepositorioBitacora
    {
        public IBitacoraDao BitacoraDao { get; set; }

        public RepositorioBitacora(IBitacoraDao bitacoraDao)
        {
            this.BitacoraDao = bitacoraDao;
        }

        public void RegistrarEnBitacora(Usuario usuario)
        {
            GlobalContext.Properties["IdUsuario"] = usuario.IdUsuario;

            var digitoVH = BitacoraDao.GenerarDVH(usuario);

            GlobalContext.Properties["RequestGuid"] = Guid.NewGuid();

            GlobalContext.Properties["dvh"] = digitoVH;
        }

        public void FiltrarBitacora(BitacoraFiltros filtros)
        {
            BitacoraDao.FiltrarBitacora(filtros);
        }

        public Bitacora LeerBitacoraConId(int bitacoraId)
        {
            return BitacoraDao.LeerBitacoraConId(bitacoraId);
        }

        public int GenerarDVH(Usuario usu)
        {
            return BitacoraDao.GenerarDVH(usu);
        }

        public int ObtenerUltimoIdBitacora()
        {
            return BitacoraDao.ObtenerUltimoIdBitacora();
        }
    }
}
