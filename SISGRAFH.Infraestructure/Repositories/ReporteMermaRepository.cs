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
    public class ReporteMermaRepository : BaseRepository<beReporteMerma>, IReporteMermaRepository
    {
        private readonly IMongoCollection<beReporteMerma> _reporteMerma;

        public ReporteMermaRepository(IMongoDatabase database) : base(database)
        {
            _reporteMerma = database.GetCollection<beReporteMerma>(MongoCollectionNames.Reporte_Merma);
        }

        public async Task<IEnumerable<beReporteMerma>> GetReporteMerma()
        {
            var reportesmerma = await _reporteMerma.AsQueryable().ToListAsync();
            return reportesmerma;
        }
        public async Task<beReporteMerma> PostReporteMerma(beReporteMerma reporteMerma)
        {
            await _reporteMerma.InsertOneAsync(reporteMerma);
            return reporteMerma;
        }
    }
}
