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

        public async Task<List<beOrden_Trabajo>> GenerarOrdenesByCotizacion(string codigo)
        {
            List<beOrden_Trabajo> ordenes = new List<beOrden_Trabajo>();
            var cotizacion = await _unitOfWork.Cotizacion.GetCotizacionByCodigoCotizacion(codigo, "Aprobado");
            cotizacion.productos_cotizados.ForEach(delegate (beProductoCotizado pc) {
                beOrden_Trabajo ot = new beOrden_Trabajo();
                ot.id_solicitud = cotizacion.id_solicitud;
                ot.id_producto = pc.id_producto;
                ot.codigo_producto = pc.codigo_producto;
                ot.instrucciones = pc.localizaciones;
                ot.estado = "En cola";
                ordenes.Add(ot);
            });
            if (ordenes.Count() > 0)
            {
                ordenes.ForEach(async x => await _unitOfWork.Orden_Trabajo.PostOrdenTrabjo(x));
            }
            return ordenes;
        }

        public async Task<beOrden_Trabajo> GetOrdenById(string id)
        {
            return await _unitOfWork.Orden_Trabajo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<beOrden_Trabajo>> GetOrdenes()
        {
            return await _unitOfWork.Orden_Trabajo.GetAllAsync();
        }

        public async Task<beOrden_Trabajo> GetOrdenesByCodigo(string codigo)
        {
            return await _unitOfWork.Orden_Trabajo.GetOrdenesByCodigo(codigo);
        }

        public async Task<IEnumerable<beOrden_Trabajo>> GetOrdenesByCodigoCotizacion(string codigo)
        {
            var solicitud = await _unitOfWork.Solicitud.GetSolicitudByCodigoCotizacion(codigo);
            return await _unitOfWork.Orden_Trabajo.GetOrdenesByIDSolicitud(solicitud.Id);
        }

        public async Task<IEnumerable<beOrden_Trabajo>> GetOrdenesByIdMaquina(string id_maquina)
        {
            return await _unitOfWork.Orden_Trabajo.GetOrdenesByMaquina(id_maquina);
        }

        public async Task<beOrden_Trabajo> PostOrden(beOrden_Trabajo ot)
        {
            return await _unitOfWork.Orden_Trabajo.PostOrdenTrabjo(ot);
        }

        public async Task<beOrden_Trabajo> UpdateOrden(beOrden_Trabajo ot)
        {
            var otDb = await _unitOfWork.Orden_Trabajo.GetByIdAsync(ot.Id);
            if (otDb == null)
            {
                return await PostOrden(ot);
            };
            otDb.AudithObject = new Audith();
            otDb.codigo_producto = ot.codigo_producto;
            otDb.codigo = ot.codigo;
            otDb.instrucciones = ot.instrucciones;
            otDb.id_solicitud = ot.id_solicitud;
            otDb.estado = ot.estado;
            otDb.id_producto = ot.id_producto;
            return await _unitOfWork.Orden_Trabajo.UpdateOneAsync(otDb);
        }
    }
}
