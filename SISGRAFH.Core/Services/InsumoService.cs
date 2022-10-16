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
    public class InsumoService : IInsumoService
    {
        private static IUnitOfWork _unitOfWork;

        public InsumoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<beInsumo> GetInsumoById(string id)
        {
            return await _unitOfWork.Insumo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<beInsumo>> GetInsumos()
        {
            return await _unitOfWork.Insumo.GetAllAsync();
        }

        public async Task<beInsumo> PostInsumo(beInsumo insumo)
        {
            return await _unitOfWork.Insumo.InsertOneAsync(insumo);
        }
    }
}
