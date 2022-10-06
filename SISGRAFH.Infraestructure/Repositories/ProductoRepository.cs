using MongoDB.Driver;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.MongoDbParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Infraestructure.Repositories
{
    public class ProductoRepository : BaseRepository<beProducto>, IProductoRepository
    {
        private readonly IMongoCollection<beProducto> _producto;

        public ProductoRepository(IMongoDatabase database) : base(database)
        {
            _producto = database.GetCollection<beProducto>(MongoCollectionNames.Productos);
        }
        public async Task<IEnumerable<beProducto>> GetProductos()
        {
            var cotizaciones = await _producto.Find(producto => true).ToListAsync();
            return cotizaciones;
        }

        public async Task<beProducto> PostProducto(beProducto producto)
        {
            await _producto.InsertOneAsync(producto);
            return producto;
        }
    }
}
