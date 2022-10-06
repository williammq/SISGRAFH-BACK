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
    public class SolicitudRepository : BaseRepository<beSolicitud>, ISolicitudRepository
    {
        private readonly IMongoCollection<beSolicitud> _solicitud;

        public SolicitudRepository(IMongoDatabase database) : base(database)
        {
            _solicitud = database.GetCollection<beSolicitud>(MongoCollectionNames.Solicitudes);
        }

        public async Task<IEnumerable<object>> GetSoliccitudes()
        {
            var solicitudes = await _solicitud.AsQueryable().ToListAsync();
            return solicitudes;
        }

        public Task<beSolicitud> PostSolicitud(beSolicitud insumo)
        {
            throw new NotImplementedException();
        }
    }
}
