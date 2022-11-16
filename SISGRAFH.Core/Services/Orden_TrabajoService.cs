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

        public async Task<List<beOrden_Trabajo>> GenerarOrdenesByCotizacion(string id_cotizacion)
        {
            List<beOrden_Trabajo> ordenes = new List<beOrden_Trabajo>();
            var cotizacion = await _unitOfWork.Cotizacion.GetByIdAsync(id_cotizacion);
            var solicitud = await _unitOfWork.Solicitud.GetSolicitudByCodigoCotizacion(cotizacion.codigo_cotizacion);
            cotizacion.productos_cotizados.ForEach(async delegate (beProductoCotizado pc) {
                beOrden_Trabajo ot = new beOrden_Trabajo();
                ot.id_solicitud = solicitud.Id;
                ot.id_producto = pc.id_producto;
                ot.codigo_producto = pc.codigo_producto;
                ot.instrucciones = pc.localizaciones;
                ot.estado = "En cola";
                ordenes.Add(ot);
                await _unitOfWork.Orden_Trabajo.InsertOneAsync(ot);
            });
            return ordenes;
        }

        public async Task<IEnumerable<beOrden_Trabajo>> GetOrdenes()
        {
            return await _unitOfWork.Orden_Trabajo.GetAllAsync();
        }

        public async Task<beOrden_Trabajo> PostOrden(beOrden_Trabajo ot)
        {
            return await _unitOfWork.Orden_Trabajo.InsertOneAsync(ot);
        }
    }
}
