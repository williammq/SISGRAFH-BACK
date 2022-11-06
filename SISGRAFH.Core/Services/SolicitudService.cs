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

        public async Task<IEnumerable<object>> GetProductosBySolicitud(string id)
        {
            return await _unitOfWork.Solicitud.GetProductosBySolicitud(id);
        }

        public async Task<beSolicitud> GetSolicitudByCodigoCotizacion(string codigo)
        {
            return await _unitOfWork.Solicitud.GetSolicitudByCodigoCotizacion(codigo);
        }

        public async Task<IEnumerable<object>> GetSolicitudes()
        {
            return await _unitOfWork.Solicitud.GetAllAsync();
        }

        public async Task<beSolicitud> PostSolicitud(beSolicitud solicitud)
        {            
            return await _unitOfWork.Solicitud.InsertOneAsync(solicitud);
        }
        public Task<beSolicitud> UpdateSolicitud(beSolicitud solicitud)
        {
            throw new NotImplementedException();
        }
    }
}
