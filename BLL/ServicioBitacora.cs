﻿using BLL.Interfaces;
using DAL.Interfaces;
using log4net;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BE;

    public class ServicioBitacora : IServicioBitacora
    {
        public IRepositorioBitacora RepositorioBitacora { get; set; }

        public ServicioBitacora(IRepositorioBitacora repositorioBitacora)
        {
            this.RepositorioBitacora = repositorioBitacora;
        }

        public void RegistrarEnBitacora(string criticidad, string mensaje, Usuario usuario)
        {
            RepositorioBitacora.RegistrarEnBitacora(criticidad, mensaje, usuario);
        }

        public void FiltrarBitacora(BitacoraFiltros filtros)
        {
            throw new NotImplementedException();
        }

        public int GenerarDVH(Usuario usu)
        {
            throw new NotImplementedException();
        }

        public List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<Guid> idUsuarios, List<string> criticidades, DateTime desde, DateTime hasta)
        {
            return RepositorioBitacora.LeerBitacoraPorUsuarioCriticidadYFecha(idUsuarios, criticidades, desde, hasta);
        }
    }
}
