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
    public class CotizacionService : ICotizacionService
    {
        private static IUnitOfWork _unitOfWork;

        public CotizacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<beCotizacion> GetCotizacionByCodigoCotizacion(string codigo)
        {
            return await _unitOfWork.Cotizacion.GetCotizacionByCodigoCotizacion(codigo);
        }

        public async Task<beCotizacion> GetCotizacionById(string id)
        {
            return await _unitOfWork.Cotizacion.GetByIdAsync(id);
        }

        public async Task<IEnumerable<beCotizacion>> GetCotizaciones()
        {
            return await _unitOfWork.Cotizacion.GetAllAsync();
        }

        public async Task<beCotizacion> PostCotizacion(beCotizacion cotizacion)
        {
            var solicitud = await _unitOfWork.Solicitud.GetSolicitudByCodigoCotizacion(cotizacion.codigo_cotizacion);
            solicitud.estado = "Cotizado";
            await _unitOfWork.Solicitud.UpdateOneAsync(solicitud);
            return await _unitOfWork.Cotizacion.InsertOneAsync(cotizacion);
        }

        public async Task<beCotizacion> UpdateCotizacion(beCotizacion cotizacion)
        {
            var cotizaciondb = await _unitOfWork.Cotizacion.GetByIdAsync(cotizacion.Id);
            if (cotizaciondb == null)
            {
                return await PostCotizacion(cotizacion);
            };
            cotizaciondb.productos_cotizados =cotizacion.productos_cotizados;
            cotizaciondb.estado =cotizacion.estado;
            cotizaciondb.id_solicitud =cotizacion.id_solicitud;
            return await _unitOfWork.Cotizacion.UpdateOneAsync(cotizaciondb);
        }
    }
}
