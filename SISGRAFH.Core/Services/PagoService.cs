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
    public class PagoService : IPagoService
    {
        private static IUnitOfWork _unitOfWork;
        private static IFileStorage _fileStorage;

        public PagoService(IUnitOfWork unitOfWork, IFileStorage fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<bePago> evaluarPago(bePago pago)
        {
            var pagoDb = await _unitOfWork.Pago.GetByIdAsync(pago.Id);
            if (pagoDb == null)
            {
                return await PostPago(pago);
            };
            
            pagoDb.estado = pago.estado;
            pagoDb.motivo_rechazo = pago.motivo_rechazo;


            return await _unitOfWork.Pago.UpdateOneAsync(pagoDb);
        }

        public async Task<bePago> PostPago(bePago pago)
        {
            for (int i=0;i<pago.url_imagen.Count;i++)
            {
                string base64String = pago.url_imagen[i].Split(",")[1];
                pago.url_imagen[i] = await _fileStorage.SaveFile(Convert.FromBase64String(base64String), "jpg", "sisgraphfiles");
            }
            var cotizacion = await _unitOfWork.Cotizacion.GetCotizacionByCodigoCotizacion(pago.codigo_cotizacion,"Enviado");
            var solicitud = await _unitOfWork.Solicitud.GetSolicitudByCodigoCotizacion(pago.codigo_cotizacion);
            solicitud.estado = "Pago en evaluacion";
            cotizacion.estado ="Aprobado";
            await _unitOfWork.Cotizacion.UpdateOneAsync(cotizacion);
            await _unitOfWork.Solicitud.UpdateOneAsync(solicitud);
            return await _unitOfWork.Pago.InsertOneAsync(pago);
        }
        public async Task<IEnumerable<bePago>> GetPago()
        {
            return await _unitOfWork.Pago.GetAllAsync();
        }
    }
}
