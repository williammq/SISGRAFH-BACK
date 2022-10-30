using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IMovimientoService
    {
        Task<IEnumerable<beMovimiento>> GetAllMovimiento();
        Task<beMovimiento> GetByIdMovimiento(string id);
        Task<beMovimiento> PostMovimiento(beMovimiento maquina);
        Task<beMovimiento> UpdateMovimiento(beMovimiento maquina);
    }
}
