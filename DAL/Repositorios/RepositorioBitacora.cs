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
        private static readonly ILog log = LogManager.GetLogger(typeof(RepositorioBitacora));

        public IBitacoraDao BitacoraDao { get; set; }

        public RepositorioBitacora(IBitacoraDao bitacoraDao)
        {
            this.BitacoraDao = bitacoraDao;
        }

        public void RegistrarEnBitacora(string criticidad, string mensaje, Usuario usuario)
        {
            GlobalContext.Properties["IdUsuario"] = usuario.IdUsuario;
            var digitoVH = BitacoraDao.GenerarDVH(usuario);
            GlobalContext.Properties["logLevel"] = criticidad;
            GlobalContext.Properties["dvh"] = digitoVH;

            log.InfoFormat(mensaje);
            
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

        public List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<Guid> idUsuarios, List<string> criticidades, DateTime desde, DateTime hasta)
        {
            return BitacoraDao.LeerBitacoraPorUsuarioCriticidadYFecha(idUsuarios, criticidades, desde, hasta);
        }
    }
}
