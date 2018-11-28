﻿using BE;

namespace DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepositorioBitacora
    {
        void RegistrarEnBitacora(string criticidad, string mensaje, Usuario usuario = null);

        void FiltrarBitacora(BitacoraFiltros filtros);       

        int GenerarDVH(Bitacora log);
        
        List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<Guid> idUsuarios, List<string> criticidades, DateTime desde, DateTime hasta);
    }
}
