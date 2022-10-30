using MongoDB.Driver;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.MongoDbParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Infraestructure.Repositories
{
    public class InsumoRepository : BaseRepository<beInsumo>, IInsumoRepository
    {
        private readonly IMongoCollection<beInsumo> _insumo;

        public InsumoRepository(IMongoDatabase database) : base(database)
        {
            _insumo = database.GetCollection<beInsumo>(MongoCollectionNames.Insumos);
        }
        public async Task<IEnumerable<object>> GetInsumos()
        {
            var maquinas = await _insumo.AsQueryable().ToListAsync();
            return maquinas;
        }

        public async Task<beInsumo> PostInsumo(beInsumo insumo)
        {
            await _insumo.InsertOneAsync(insumo);
            return insumo;
        }

        public async Task<IEnumerable<beInsumo>> GetInsumoByCategoria(string categoria)
        {
            var insumos = await _insumo.Find(insumo => insumo.categoria == categoria).ToListAsync();
            insumos.Where(x => x.categoria == categoria);
            return insumos;
        }

        public async Task<beInsumo> GetInsumoByNombre(string nombre)
        {
            var insumo = await _insumo.Find(insumo => insumo.nombre == nombre).FirstOrDefaultAsync();
            return insumo;
        }
    }
}
