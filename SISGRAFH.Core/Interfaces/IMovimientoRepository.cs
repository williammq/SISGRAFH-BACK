using SISGRAFH.Core.Entities;
using System;
using SISGRAFH.Core.DTOs.Cotizacion;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IMovimientoRepository : IRepository<beMovimiento>
    {
        Task<IEnumerable<beMovimiento>> GetAllMovimiento();
        Task<beMovimiento> GetByIdMovimiento(string id);
        Task<beMovimiento> PostMovimiento(beMovimiento movimiento);
        Task<beMovimiento> UpdateMovimiento(beMovimiento movimiento);

    }
}
