﻿using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IInsumoService
    {
        Task<IEnumerable<beInsumo>> GetInsumos();
        Task<beInsumo> PostInsumo(beInsumo insumo);
        Task<beInsumo> GetInsumoById(string id);
        Task<beInsumo> UpdateInsumo(beInsumo insumo);
        Task<IEnumerable<beInsumo>> GetInsumoByCategoria(string categoria);
        Task<beInsumo> GetInsumoByNombre(string nombre);
    }
}
