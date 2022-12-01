using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.DTOs.Login;
namespace SISGRAFH.Core.Interfaces
{
    public interface IReporteVentaRepository : IRepository<beReporteVenta>
    {
        Task<beReporteVenta> PostReporteVenta(beReporteVenta venta);
        Task<beReporteVenta> GetReporteByCliente(string Cliente);
        Task<IEnumerable<beReporteVenta>> GetReporteventa();
    }
}
