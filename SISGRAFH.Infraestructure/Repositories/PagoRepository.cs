using MongoDB.Driver;
using SISGRAFH.Core.DTOs.Pago;
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
    public class PagoRepository : BaseRepository<bePago>, IPagoRepository
    {
        private readonly IMongoCollection<bePago> _pago;

        public PagoRepository(IMongoDatabase database): base(database)
        {
            _pago = database.GetCollection<bePago>(MongoCollectionNames.Pagos);
        }

        public async Task<bePago> PostPago(bePago pago)
        {
            await _pago.InsertOneAsync(pago);
            return pago;
        }
    }
}
