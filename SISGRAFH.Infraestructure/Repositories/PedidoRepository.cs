using MongoDB.Driver;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.MongoDbParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SISGRAFH.Infraestructure.Repositories
{
    public class PedidoRepository : BaseRepository<bePedido>, IPedidoRepository
    {
        private readonly IMongoCollection<bePedido> _pedido;

        public PedidoRepository(IMongoDatabase database) : base(database)
        {
            _pedido = database.GetCollection<bePedido>(MongoCollectionNames.Pedidos);
        }

        public async Task<IEnumerable<object>> GetPedidos()
        {
            var pedidos = await _pedido.AsQueryable().ToListAsync();
            return pedidos;
        }

        public async Task<IEnumerable<object>> GetPedidosByCliente(string id)
        {
            var pedidos = await _pedido.Find(x => x.id_cliente == id).ToListAsync();
            return pedidos;
        }

        public async Task<IEnumerable<object>> GetProductosByPedido(string id)
        {
            var pedido = await _pedido.Find(x => x.Id == id).FirstOrDefaultAsync();
            List<object> productos = new List<object>();
            productos.AddRange(pedido.productos.AsQueryable().ToList());
            return productos;
        }
    }
}
