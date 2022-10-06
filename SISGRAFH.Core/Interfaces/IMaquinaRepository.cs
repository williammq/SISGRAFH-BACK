﻿using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IMaquinaRepository : IRepository<beMaquina>
    {
        Task<IEnumerable<object>> GetMaquinas();
        Task<beMaquina> PostMaquina(beMaquina maquina);
    }
}
