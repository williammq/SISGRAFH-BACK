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
    public class SolicitudService : ISolicitudService
    {
        private static IUnitOfWork _unitOfWork;

        public SolicitudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<object>> GetSolicitudes()
        {
            return await _unitOfWork.Solicitud.GetAllAsync();
        }

        public Task<beSolicitud> PostSolicitud(beSolicitud solicitud)
        {
            throw new NotImplementedException();
        }

        public Task<beSolicitud> UpdateSolicitud(beSolicitud solicitud)
        {
            throw new NotImplementedException();
        }
    }
}
