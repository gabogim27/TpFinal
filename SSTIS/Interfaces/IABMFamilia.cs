﻿using System.Windows.Forms;
using BE;

namespace SSTIS.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IABMFamilia
    {
        void Show();
        DialogResult ShowDialog();
        Familia ObtenerFamiliaSeleccionada();
    }
}