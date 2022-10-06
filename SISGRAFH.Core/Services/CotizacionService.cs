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
        public async Task<IEnumerable<beCotizacion>> GetCotizaciones()
        {
            return await _unitOfWork.Cotizacion.GetAllAsync();
        }

        public async Task<beCotizacion> PostMaquina(beCotizacion cotizacion)
        {
            return await _unitOfWork.Cotizacion.InsertOneAsync(cotizacion);
        }

        public async Task<beCotizacion> UpdateMaquina(beCotizacion cotizacion)
        {
            throw new NotImplementedException();
        }
    }
}
