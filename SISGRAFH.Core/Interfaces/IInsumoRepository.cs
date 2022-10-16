using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IInsumoRepository: IRepository<beInsumo>
    {
        Task<IEnumerable<object>> GetInsumos();
        Task<beInsumo> PostInsumo(beInsumo insumo);
    }
}
