using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<beProducto>> GetProductos();
        Task<beProducto> PostProducto(beProducto cotizacion);
        Task<beProducto> UpdateProducto(beProducto cotizacion);
    }
}
