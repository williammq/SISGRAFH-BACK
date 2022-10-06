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
    public class MaquinaService : IMaquinaService
    {
        private static IUnitOfWork _unitOfWork;

        public MaquinaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<beMaquina>> GetMaquinas()
        {
            return await _unitOfWork.Maquina.GetAllAsync();
        }

        public async Task<beMaquina> PostMaquina(beMaquina maquina)
        {
            return await _unitOfWork.Maquina.InsertOneAsync(maquina);
        }

        public async Task<beMaquina> UpdateMaquina(beMaquina maquina)
        {
            throw new NotImplementedException();
        }
    }
}
