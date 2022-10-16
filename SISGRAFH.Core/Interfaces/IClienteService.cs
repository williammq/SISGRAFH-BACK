using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<beCliente>> GetAllClientes();
        Task<beCliente> GetClienteByCorreo(string correo);
    }
}
