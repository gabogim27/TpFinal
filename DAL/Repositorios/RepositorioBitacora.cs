using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using BE;
using DAL.Dao;
using DAL.Interfaces;
using EasyEncryption;
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
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";

        public RepositorioBitacora(IBitacoraDao bitacoraDao)
        {
            this.BitacoraDao = bitacoraDao;
        }

        public void RegistrarEnBitacora(string criticidad, string mensaje, Usuario usuario = null)
        {
            BitacoraDao.RegistrarEnBitacora(criticidad, mensaje, usuario);
        }

        public void FiltrarBitacora(BitacoraFiltros filtros)
        {
            BitacoraDao.FiltrarBitacora(filtros);
        }       

        public int GenerarDVH(Bitacora log)
        {
            return BitacoraDao.GenerarDVH(log);
        }        

        public List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<Guid> idUsuarios, List<string> criticidades, DateTime desde, DateTime hasta)
        {
            return BitacoraDao.LeerBitacoraPorUsuarioCriticidadYFecha(idUsuarios, criticidades, desde, hasta);
        }
    }
}
