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
    public class Orden_TrabajoRepository : BaseRepository<beOrden_Trabajo>, IOrden_TrabajoRepository
    {
        private readonly IMongoCollection<beOrden_Trabajo> _orden;

        public Orden_TrabajoRepository(IMongoDatabase database) : base(database)
        {
            _orden = database.GetCollection<beOrden_Trabajo>(MongoCollectionNames.Orden_Trabajo);
        }
        public async Task<IEnumerable<beOrden_Trabajo>> GetOrdenes()
        {
            var ordenes = await _orden.Find(o => true).ToListAsync();
            return ordenes;
        }

        public async Task<IEnumerable<beOrden_Trabajo>> GetOrdenesByIDSolicitud(string id_solicitud)
        {
            var ordenes = await _orden.Find(o => o.id_solicitud==id_solicitud).ToListAsync();
            return ordenes;
        }
    }
}
