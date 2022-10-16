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
    public class CatalogoService : ICatalogoService
    {
        private static IUnitOfWork _unitOfWork;

        public CatalogoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<beCatalogo>> GetCatalogo()
        {
            return await _unitOfWork.Catalogo.GetAllAsync();
        }

        public Task<beCatalogo> PostCatalogo(beCatalogo catalogo)
        {
            throw new NotImplementedException();
        }

        public Task<beCatalogo> UpdateCatalogo(beCatalogo catalogo)
        {
            throw new NotImplementedException();
        }
    }
}
