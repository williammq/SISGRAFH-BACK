using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.BlobStorage;
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
        private static IFileStorage _fileStorage;


        public SolicitudService(IUnitOfWork unitOfWork, IFileStorage fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<beSolicitud> GetSolicitudById(string id)
        {
            return await _unitOfWork.Solicitud.GetByIdAsync(id);
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
            solicitud.productos.ForEach(async delegate (beProducto_solicitud p) {
                for (int i = 0; i < p.archivos.Count; i++)
                {
                    string base64String = p.archivos[i].Split(",")[1];
                    p.archivos[i] = await _fileStorage.SaveFile(Convert.FromBase64String(base64String), "jpg", "sisgraphfiles");
                }
            });
            return await _unitOfWork.Solicitud.InsertOneAsync(solicitud);
        }
        public Task<beSolicitud> UpdateSolicitud(beSolicitud solicitud)
        {
            throw new NotImplementedException();
        }
    }
}
