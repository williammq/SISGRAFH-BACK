using MongoDB.Driver;
using SISGRAFH.Core.DTOs.Login;
using SISGRAFH.Core.DTOs.ReporteVenta;
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
    public class ReporteVentaServiceRepository : BaseRepository<beReporteVenta>, IReporteVentaRepository
    {
        private readonly IMongoCollection<beReporteVenta> _ventas;

        public ReporteVentaServiceRepository(IMongoDatabase database) : base(database)
        {
            _ventas = database.GetCollection<beReporteVenta>(MongoCollectionNames.Ventas);
        }

        public async Task<beReporteVenta> GetVentaByCliente(string Cliente)
        {
            var venta = await _ventas.Find(venta => venta.Id == Cliente).FirstOrDefaultAsync();
            return venta;
        }

        public async Task<beReporteVenta> PostReporteVenta(beReporteVenta venta)
        {
            await _ventas.InsertOneAsync(venta);
            return venta;
        }

        public async Task<IEnumerable<beReporteVenta>> GetReporteventa()
        {
            var venta = await _ventas.Find(venta => true).ToListAsync();
            return venta;
        }

        public async Task<beReporteVenta> GetReporteByCliente(string idCliente)
        {
            var venta = await _ventas.Find(venta => venta.Id == idCliente).FirstOrDefaultAsync();
            return venta;
        }
    }
}
