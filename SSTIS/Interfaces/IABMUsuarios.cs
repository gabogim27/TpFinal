﻿using System.Windows.Forms;
using BE;

namespace SSTIS.Interfaces
{
    public interface IABMUsuarios
    {
        void Show();
        Form MdiParent { get; set; }
        DialogResult ShowDialog();
        Usuario usuarioSeleccionado();
    }
}
