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
    public class ReporteProduccionReposistory : BaseRepository<beReporteProduccion>, IReporteProduccionRepository
    {
        private readonly IMongoCollection<beReporteProduccion> _reporteProduccion;

        public ReporteProduccionReposistory(IMongoDatabase database) : base(database)
        {
            _reporteProduccion = database.GetCollection<beReporteProduccion>(MongoCollectionNames.Reporte_Produccion);
        }

        public async Task<IEnumerable<beReporteProduccion>> GetReportesProduccionById_Ot(string id_orden_trabajo)
        {
            var reportes = await _reporteProduccion.Find(x=>x.id_orden_trabajo == id_orden_trabajo).ToListAsync();
            return reportes;
        }

        public async Task<beReporteProduccion> PostReporteProduccion(beReporteProduccion reporteProduccion)
        {
            await _reporteProduccion.InsertOneAsync(reporteProduccion);
            return reporteProduccion;
        }
    }
}
