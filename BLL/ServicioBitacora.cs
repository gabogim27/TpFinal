using BLL.Interfaces;
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
    }
}
