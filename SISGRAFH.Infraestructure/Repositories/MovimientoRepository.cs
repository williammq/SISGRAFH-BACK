using System;
using MongoDB.Driver;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.MongoDbParams;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Infraestructure.Repositories
{
    public class MovimientoRepository : BaseRepository<beMovimiento>, IMovimientoRepository
    {
        private readonly IMongoCollection<beMovimiento> _movimiento;

        public MovimientoRepository(IMongoDatabase database) : base(database)
        {
            _movimiento = database.GetCollection<beMovimiento>(MongoCollectionNames.Movimientos);
        }

        public async Task<IEnumerable<beMovimiento>> GetAllMovimiento()
        {
            var movimientos = await _movimiento.Find(movimiento => true).ToListAsync();
            return movimientos;
        }

        public async Task<beMovimiento> GetByIdMovimiento(string id)
        {
            var movimiento = await _movimiento.Find(movimiento => movimiento.Id == id).FirstOrDefaultAsync();
            return movimiento;
        }

        public async Task<beMovimiento> PostMovimiento(beMovimiento movimiento)
        {
            await _movimiento.InsertOneAsync(movimiento);
            return movimiento;
        }

        public async Task<beMovimiento> UpdateMovimiento(beMovimiento movimiento)
        {
            var filter = Builders<beMovimiento>.Filter.Eq(doc => doc.Id, movimiento.Id);
            await _movimiento.FindOneAndReplaceAsync(filter, movimiento);
            return movimiento;
        }
    }
}
