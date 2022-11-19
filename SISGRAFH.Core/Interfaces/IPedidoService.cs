using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<object>> GetPedidos();
        Task<IEnumerable<object>> GetPedidosByCliente(string id);
        Task<IEnumerable<object>> GetProductosByPedido(string id);
    }
}
