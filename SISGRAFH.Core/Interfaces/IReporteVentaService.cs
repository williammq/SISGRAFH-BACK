using SISGRAFH.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IReporteVentaService
    {
        Task<beReporteVenta> PostReporteVenta(beReporteVenta venta);
        Task<IEnumerable<beReporteVenta>> consulventa();
        Task<IEnumerable<beReporteVenta>> GetReporteventa();
    }
}
