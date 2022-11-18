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
    public class UbigeoService : IUbigeoService
    {
        private static IUnitOfWork _unitOfWork;
        public UbigeoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<beUbigeo>> GetAllUbigeo()
        {
            return await _unitOfWork.Ubigeo.GetAllUbigeo();
        }

        public async Task<beUbigeo> GetByIdUbigeo(string id)
        {
            return await _unitOfWork.Ubigeo.GetByIdUbigeo(id);
        }
    }
}
