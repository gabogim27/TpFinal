﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Interfaces
{
    public interface ILocalidadDao
    {
        List<Localidad> GetLocalidadesByProvinciaId(Guid provinciaId);
    }
}