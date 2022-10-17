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
    public class MovimientoService : IMovimientoService
    {
        private static IUnitOfWork _unitOfWork;
        public MovimientoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<beMovimiento>> GetMovimiento()
        {
            return await _unitOfWork.Movimiento.GetAllAsync();
        }

        public async Task<beMovimiento> PostMovimiento(beMovimiento movimiento)
        {
            return await _unitOfWork.Movimiento.InsertOneAsync(movimiento);
        }

        public async Task<beMovimiento> UpdateMovimiento(beMovimiento movimiento)
        {
            var movimientodb = await _unitOfWork.Movimiento.GetByIdAsync(movimiento.Id);
            if (movimientodb == null)
            {
                return await PostMovimiento(movimiento);
            };
            movimientodb.codigo = movimiento.codigo;
            /*movimientodb.origen = new beOrigen
            {
                ubigeo = movimiento.origen.ubigeo,
                local = movimiento.origen.local,
                direccion = movimiento.origen.direccion,
                emisor = movimiento.origen.emisor
            };*/
            /*movimientodb.destino = new beDestino
            {
                ubigeo = movimiento.origen.ubigeo,
                local = movimiento.origen.local,
                direccion = movimiento.origen.direccion,
                receptor = movimiento.origen.receptor
            };*/
            movimientodb.origen = movimiento.origen;
            movimientodb.destino = movimiento.destino;
            movimientodb.insumo = movimiento.insumo;
            movimientodb.tipo = movimiento.tipo;
            movimientodb.cantidad = movimiento.cantidad;
            movimientodb.transporte = movimiento.transporte;
            movimientodb.fecha_movimiento = movimiento.fecha_movimiento;
            movimientodb.estado = movimiento.estado;

            return await _unitOfWork.Movimiento.UpdateOneAsync(movimientodb);
        }
    }
}
