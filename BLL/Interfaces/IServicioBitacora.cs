﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL.Interfaces
{
    public interface IServicioBitacora
    {
        void RegistrarEnBitacora(Usuario usuario);

        void FiltrarBitacora(BitacoraFiltros filtros);

        Bitacora LeerBitacoraConId(int bitacoraId);

        int GenerarDVH(Usuario usu);

        int ObtenerUltimoIdBitacora();

        List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<Guid> idUsuarios, List<string> criticidades, DateTime desde, DateTime hasta);
    }
}
