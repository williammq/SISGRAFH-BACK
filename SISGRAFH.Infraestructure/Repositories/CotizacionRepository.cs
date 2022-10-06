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
    public class CotizacionRepository : BaseRepository<beCotizacion>, ICotizacionRepository
    {
        private readonly IMongoCollection<beCotizacion> _cotizacion;

        public CotizacionRepository(IMongoDatabase database) : base(database)
        {
            _cotizacion = database.GetCollection<beCotizacion>(MongoCollectionNames.Cotizaciones);
        }
        public async Task<IEnumerable<beCotizacion>> GetCotizaciones()
        {
            var cotizaciones = await _cotizacion.Find(cotizacion => true).ToListAsync();
            return cotizaciones;
        }

        public async Task<beCotizacion> PostCotizacion(beCotizacion cotizacion)
        {
            await _cotizacion.InsertOneAsync(cotizacion);
            return cotizacion;
        }
    }
}
