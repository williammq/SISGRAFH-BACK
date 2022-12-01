using SISGRAFH.Core.Entities;
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
        Task<bePedido> GetPedidosById(string id);
        Task<bePedido> GetPedidosById_solicitud(string id_solicitud);
        Task<IEnumerable<object>> GetTrackigPedidosByCliente(string id);
        Task<IEnumerable<object>> GetProductosByPedido(string id);
    }
}
