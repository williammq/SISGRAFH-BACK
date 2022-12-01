using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IReporteMermaService
    {
        Task<IEnumerable<beReporteMerma>> GetReporteMerma();
        Task<beReporteMerma> PostReporteMerma(beReporteMerma reporteMerma);
        Task<beReporteMerma> GetReporteMermaById(string id);
        Task<beReporteMerma> UpdateReporteMerma(beReporteMerma reporteMerma);
    }
}
