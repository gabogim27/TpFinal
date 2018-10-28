using System;
using System.Collections.Generic;
using BE;

namespace DAL.Interfaces
{
    public interface IRepositorioLocalidad
    {
        List<Localidad> GetLocalidadesByProvinciaId(Guid provinciaId);
    }
}
