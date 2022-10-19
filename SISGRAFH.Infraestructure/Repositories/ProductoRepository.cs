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
        private readonly IMongoCollection<beCatalogo> _catalogo;

        public ProductoRepository(IMongoDatabase database) : base(database)
        {
            _producto = database.GetCollection<beProducto>(MongoCollectionNames.Productos);
            _catalogo = database.GetCollection<beCatalogo>(MongoCollectionNames.Catalogo);
        }
        public async Task<IEnumerable<beProducto>> GetProductosInCatalogo()
        {
            List<beProducto> productosCatalogo = new List<beProducto>();
            var catalogo = await _catalogo.Find(catalogo => catalogo.estadoProducto == true).ToListAsync();
            catalogo.ForEach(delegate(beCatalogo c) {
               beProducto p =  _producto.Find(p => p.Id == c.id_producto).FirstOrDefault();
                productosCatalogo.Add(p);
            });
            return productosCatalogo;
        }

        public async Task<beProducto> PostProducto(beProducto producto)
        {
            await _producto.InsertOneAsync(producto);
            return producto;
        }
    }
}
