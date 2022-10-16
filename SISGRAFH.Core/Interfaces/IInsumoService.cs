using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IInsumoService
    {
        Task<IEnumerable<object>> GetInsumos();
        Task<beInsumo> PostInsumo(beInsumo insumo);
        Task<object> GetInsumoById(string id);

    }
}
