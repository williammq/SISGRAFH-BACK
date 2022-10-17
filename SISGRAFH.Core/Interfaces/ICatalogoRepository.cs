using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface ICatalogoRepository:IRepository<beCatalogo>
    {
        Task<IEnumerable<beCatalogo>> GetCatalogo();

        Task<beCatalogo> PostCatalogo(beCatalogo catalogo);
    }
}