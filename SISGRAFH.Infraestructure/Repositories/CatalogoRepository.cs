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
    public class CatalogoRepository : BaseRepository<beCatalogo>, ICatalogoRepository
    {
        private readonly IMongoCollection<beCatalogo> _catalogo;

        public CatalogoRepository(IMongoDatabase database) : base(database)
        {
            _catalogo = database.GetCollection<beCatalogo>(MongoCollectionNames.Catalogo);
        }
        public async Task<IEnumerable<beCatalogo>> GetCatalogo()
        {
            var catalogos = await _catalogo.Find(catalogo => true).ToListAsync();
            return catalogos;
        }
        public async Task<IEnumerable<beCatalogo>> GetCatalogoById(string id)
        {
            var catalogos = await _catalogo.Find(catalogo => catalogo.Id == id).ToListAsync();
            return catalogos;
        }

        public async Task<beCatalogo> PostCatalogo(beCatalogo catalogo)
        {
            await _catalogo.InsertOneAsync(catalogo);
            return catalogo;
            
        }
        public async Task<beCatalogo> GetCatalogoByIdProducto(string id_producto)
        {
            var catalogo= await _catalogo.Find(catalogo => catalogo.id_producto == id_producto).FirstOrDefaultAsync();
            return catalogo;
        }
    }
}