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
    public class PagoService : IPagoService
    {
        private static IUnitOfWork _unitOfWork;

        public PagoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bePago> evaluarPago(bePago pago)
        {
            var pagoDb = await _unitOfWork.Pago.GetByIdAsync(pago.Id_cliente);
            if (pagoDb == null)
            {
                return await PostPago(pago);
            };
            
            pagoDb.estado = pago.estado;


            return await _unitOfWork.Pago.UpdateOneAsync(pagoDb);
        }

        public async Task<bePago> PostPago(bePago pago)
        {
            pago.Id = null;
            return await _unitOfWork.Pago.InsertOneAsync(pago);
        }
    }
}
