using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Services
{
    public class ProductoService : IProductoService
    {
        private static IUnitOfWork _unitOfWork;

        public ProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<beProducto>> GetProductos()
        {
            return await _unitOfWork.Producto.GetAllAsync();
        }

        public Task<beProducto> PostProducto(beProducto cotizacion)
        {
            throw new NotImplementedException();
        }

        public Task<beProducto> UpdateProducto(beProducto cotizacion)
        {
            throw new NotImplementedException();
        }
    }
}
