using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface ISolicitudRepository : IRepository<beSolicitud>
    {
        Task<IEnumerable<object>> GetSoliccitudes();
        Task<beSolicitud> PostSolicitud(beSolicitud insumo);
    }
}
