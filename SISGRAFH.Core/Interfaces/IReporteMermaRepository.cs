using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IReporteMermaRepository:IRepository<beReporteMerma>
    {
        Task<IEnumerable<beReporteMerma>> GetReporteMerma();
        Task<beReporteMerma> PostReporteMerma(beReporteMerma reporteMerma);
    }
}
