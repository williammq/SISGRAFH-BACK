using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IProductoRepository:IRepository<beProducto>
    {
        Task<IEnumerable<beProducto>> GetProductos();
        Task<beProducto> PostProducto(beProducto producto);
    }
}
