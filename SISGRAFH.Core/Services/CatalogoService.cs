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

        public async Task<beCatalogo> GetCatalogoById(string id)
        {
            return await _unitOfWork.Catalogo.GetByIdAsync(id);
        }

        public async Task<beCatalogo> PostCatalogo(beCatalogo catalogo)
        {
            return await _unitOfWork.Catalogo.InsertOneAsync(catalogo);
        }

        public async Task<beCatalogo> UpdateCatalogo(beCatalogo catalogo)
        {
            var catalogoDb = await _unitOfWork.Catalogo.GetByIdAsync(catalogo.Id);
            if (catalogoDb == null)
            {
                return await PostCatalogo(catalogo);
            };
            catalogoDb.idProducto = catalogo.idProducto;
            catalogoDb.tamanios = catalogo.tamanios;
            catalogoDb.tipos_hoja = catalogo.tipos_hoja;
            catalogoDb.estadoProducto = catalogo.estadoProducto;

            return await _unitOfWork.Catalogo.UpdateOneAsync(catalogoDb);
        }
        
    
        
    }
}
