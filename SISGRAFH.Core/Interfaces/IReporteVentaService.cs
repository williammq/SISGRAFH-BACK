using SISGRAFH.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IReporteVentaService
    {
        Task<IEnumerable<beReporteVenta>> consulventa();
    }
}
