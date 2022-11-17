using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface ITrabajadorService
    {
        Task<IEnumerable<beTrabajador>> GetAllTrabajadores();
        Task<beTrabajador> InsertTrabajador(beTrabajador _beTrabajador);
        Task<beTrabajador> UpdateTrabajador(beTrabajador _beTrabajador);
        Task<beTrabajador> GetTrabajadorById(string id);
    }
}
