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

        public async Task<beReporteProduccion> UpdateReporteProduccion(beReporteProduccion reporteProduccion)
        {
            var reporteProduccionDb = await _unitOfWork.ReporteProduccion.GetByIdAsync(reporteProduccion.Id);
            if (reporteProduccionDb == null)
            {
                return await PostReporteProduccion(reporteProduccion);
            };
            reporteProduccionDb.AudithObject = new Audith();
            reporteProduccionDb.id_maquina = reporteProduccion.id_maquina;
            reporteProduccionDb.id_orden_trabajo = reporteProduccion.id_orden_trabajo;
            reporteProduccionDb.id_usuario = reporteProduccion.id_usuario;
            reporteProduccionDb.insumos_entrada = reporteProduccion.insumos_entrada;
            reporteProduccionDb.insumos_salida = reporteProduccion.insumos_salida;
            reporteProduccionDb.fecha_hora_inicio = reporteProduccion.fecha_hora_inicio;
            reporteProduccionDb.fecha_hora_fin = reporteProduccion.fecha_hora_fin;
            reporteProduccionDb.estado = reporteProduccion.estado;
            reporteProduccionDb.entrada = reporteProduccion.entrada;
            reporteProduccionDb.salida = reporteProduccion.salida;
            reporteProduccionDb.numero_instruccion = reporteProduccion.numero_instruccion;
            return await _unitOfWork.ReporteProduccion.UpdateOneAsync(reporteProduccionDb);
        }
    }
}
