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
    public class ClienteRepository : BaseRepository<beCliente>, IClienteRepository
    {
        private readonly IMongoCollection<beCliente> _cliente;
        public ClienteRepository(IMongoDatabase database) : base(database)
        {
            _cliente = database.GetCollection<beCliente>(MongoCollectionNames.Clientes);
        }

        public async Task<IEnumerable<beCliente>> GetClienteByCorreo(string correo)
        {
            var clientes = await _cliente.Find(cliente => cliente.Correo==correo).ToListAsync();
            return clientes;
        }

        public async Task<IEnumerable<beCliente>> GetClienteById(string id)
        {
            var clientes = await _cliente.Find(cliente => cliente.Id == id).ToListAsync();
            return clientes;
        }
    }
}
