using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Services
{
    public class Orden_TrabajoService : IOrden_TrabajoService
    {
        private static IUnitOfWork _unitOfWork;

        public Orden_TrabajoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<beOrden_Trabajo>> GetOrdenes()
        {
            return await _unitOfWork.Orden_Trabajo.GetAllAsync();
        }

        public async Task<beOrden_Trabajo> PostOrden(beOrden_Trabajo ot)
        {
            throw new NotImplementedException();
        }
    }
}
