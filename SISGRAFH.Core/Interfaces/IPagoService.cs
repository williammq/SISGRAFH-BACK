using SISGRAFH.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IPagoService
    {
        Task<bePago> PostPago(bePago pago);
        Task<bePago> evaluarPago(bePago pago);
        Task<IEnumerable<bePago>> GetPago();
        Task<bePago> GetPagoById(string id);
    }
}
