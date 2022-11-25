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
    public class ReporteProduccionService : IReporteProduccionService
    {
        private static IUnitOfWork _unitOfWork;

        public ReporteProduccionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<beReporteProduccion>> GetReportesProduccion()
        {
            return await _unitOfWork.ReporteProduccion.GetAllAsync();
        }

        public async Task<IEnumerable<beReporteProduccion>> GetReportesProduccionById_Ot(string id_orden_trabajo)
        {
            return await _unitOfWork.ReporteProduccion.GetReportesProduccionById_Ot(id_orden_trabajo);
        }

        public async Task<beReporteProduccion> PostReporteProduccion(beReporteProduccion reporteProduccion)
        {
            return await _unitOfWork.ReporteProduccion.InsertOneAsync(reporteProduccion);
        }
    }
}
