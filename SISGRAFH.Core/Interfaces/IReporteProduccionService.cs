using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IReporteProduccionService
    {
        Task<beReporteProduccion> PostReporteProduccion(beReporteProduccion reporteProduccion);
        Task<IEnumerable<beReporteProduccion>> GetReportesProduccion();
        Task<IEnumerable<beReporteProduccion>> GetReportesProduccionById_Ot(string id_orden_trabajo);
    }
}
