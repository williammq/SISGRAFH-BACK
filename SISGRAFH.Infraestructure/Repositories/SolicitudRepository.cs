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

        public async Task<IEnumerable<object>> GetSolicitudes()
        {
            var solicitudes = await _solicitud.AsQueryable().ToListAsync();
            return solicitudes;
        }
        public Task<beSolicitud> PostSolicitud(beSolicitud insumo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<object>> GetProductosBySolicitud(string id)
        {
            var solicitudes = await _solicitud.AsQueryable().ToListAsync();
            var solicitud_encontrada = solicitudes.Where(x => x.Id == id).FirstOrDefault();
            List<object> productos = new List<object>();
            productos.AddRange(solicitud_encontrada.productos.AsQueryable().ToList());
            return productos;
        }
    }
}
