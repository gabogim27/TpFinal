﻿using BE;

namespace DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioPoliza : IRepositorioPoliza
    {
        public IPolizaDao PolizaDaoImplementor;

        public RepositorioPoliza(IPolizaDao PolizaDaoImplementor)
        {
            this.PolizaDaoImplementor = PolizaDaoImplementor;
        }

        public int TraerUlitmoNumeroDePoliza()
        {
            return PolizaDaoImplementor.TraerUlitmoNumeroDePoliza();
        }

        public List<Cobertura> TraerCoberturas()
        {
            return PolizaDaoImplementor.TraerCoberturas();
        }
    }
}
