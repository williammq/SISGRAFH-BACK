using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface ICatalogoService
    {
        Task<IEnumerable<beCatalogo>> GetCatalogo();
        Task<beCatalogo> GetCatalogoById(string  id);
        Task<beCatalogo> GetCatalogoByIdProducto(string id_producto);
        Task<beCatalogo> PostCatalogo(beCatalogo catalogo);
        Task<beCatalogo> UpdateCatalogo(beCatalogo catalogo);
    }
}