using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IUbigeoRepository : IRepository<beUbigeo>
    {
        Task<List<beUbigeo>> GetAllUbigeo();
        Task<beUbigeo> GetByIdUbigeo(string id);
    }
}
