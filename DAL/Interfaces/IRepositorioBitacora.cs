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
        void RegistrarEnBitacora(Usuario usuario);

        void FiltrarBitacora(BitacoraFiltros filtros);

        Bitacora LeerBitacoraConId(int bitacoraId);

        int GenerarDVH(Usuario usu);

        int ObtenerUltimoIdBitacora();

        List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<Guid> idUsuarios, List<string> criticidades, DateTime desde, DateTime hasta);
    }
}
