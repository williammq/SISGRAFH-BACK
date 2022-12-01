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
    public class ReporteMermaService:IReporteMermaService
    {
        private static IUnitOfWork _unitOfWork;

        public ReporteMermaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<beReporteMerma>> GetReporteMerma()
        {
            return await _unitOfWork.ReporteMerma.GetAllAsync();
        }

        public async Task<beReporteMerma> GetReporteMermaById(string id)
        {
            return await _unitOfWork.ReporteMerma.GetByIdAsync(id);
        }

        public async Task<beReporteMerma> PostReporteMerma(beReporteMerma reporteMerma)
        {
            return await _unitOfWork.ReporteMerma.InsertOneAsync(reporteMerma);
        }

        public async Task<beReporteMerma> UpdateReporteMerma(beReporteMerma reporteMerma)
        {
            var reportemermaDb = await _unitOfWork.ReporteMerma.GetByIdAsync(reporteMerma.Id);
            if (reportemermaDb == null)
            {
                return await PostReporteMerma(reporteMerma);
            }
            reportemermaDb.Fecha = reporteMerma.Fecha;
            reportemermaDb.Motivo = reporteMerma.Motivo;
            reportemermaDb.Insumo = reporteMerma.Insumo;
            reportemermaDb.Trabajador = reporteMerma.Trabajador;
            reportemermaDb.IdReporte = reporteMerma.IdReporte;

            return await _unitOfWork.ReporteMerma.UpdateOneAsync(reportemermaDb);
        }
    }
}
