﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL.Interfaces
{
    public interface IServicioPoliza
    {
        int TraerUlitmoNumeroDePoliza();
        bool Create(Poliza entity);
        List<Cobertura> TraerCoberturas();
    }
}
