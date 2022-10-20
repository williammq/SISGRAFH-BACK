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

        public async Task<beProducto> GetProductoById(string id)
        {
            return await _unitOfWork.Producto.GetByIdAsync(id);
        }

        public async Task<IEnumerable<beProducto>> GetProductos()
        {
            return await _unitOfWork.Producto.GetAllAsync();
        }

        public async Task<IEnumerable<beProducto>> GetProductosCatalogo()
        {
            return await _unitOfWork.Producto.GetProductosInCatalogo();
        }

        public async Task<beProducto> PostProducto(beProducto producto)
        {
            return await _unitOfWork.Producto.InsertOneAsync(producto);
        }

        public async Task<beProducto> UpdateProducto(beProducto producto)
        {
            var productoDb = await _unitOfWork.Producto.GetByIdAsync(producto.Id);
            if (productoDb == null)
            {
                return await PostProducto(producto);
            };
            productoDb.nombre = producto.nombre;
            productoDb.descripcion = producto.descripcion;
            productoDb.url_imagen = producto.url_imagen;

            return await _unitOfWork.Producto.UpdateOneAsync(productoDb);
        }
    }
}
