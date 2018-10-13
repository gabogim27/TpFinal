﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDigitoVerificador
    {
        int CalcularDVHorizontal(string entidad, List<string> columnasString, List<int> columnasInt);
    }
}