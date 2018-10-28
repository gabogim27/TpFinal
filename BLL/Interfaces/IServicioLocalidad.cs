using System;
using System.Collections.Generic;
using BE;

namespace BLL.Interfaces
{
    public interface IServicioLocalidad
    {
        List<Localidad> GetLocalidadesByProvinciaId(Guid provinciaId);
    }
}
