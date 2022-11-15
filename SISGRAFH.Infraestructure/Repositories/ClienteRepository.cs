using MongoDB.Bson;
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
        public async Task <IEnumerable<beCliente>> GetClienteByNombreApellido(string nombre, string apellidopaterno, string apellidomaterno) {
            var clientes = await _cliente.Find(cliente => cliente.Nombre == nombre && cliente.ApellidoPaterno == apellidopaterno && cliente.ApellidoMaterno == apellidomaterno).ToListAsync();
            return clientes;

        }

        public async Task<IEnumerable<beCliente>> GetClienteByNumeroDocumento(string numeroDocumento)
        {
            var clientes = await _cliente.Find(cliente => cliente.NumeroDocumento==numeroDocumento).ToListAsync();
            return clientes;
        }
        public async Task<beCliente> GetClienteByProperty(beCliente beCliente)
        {
            var clientes = await _cliente.Find(cliente => (cliente.NumeroDocumento == beCliente.NumeroDocumento) || (cliente.Correo == beCliente.Correo) || (cliente.Telefono == beCliente.Telefono) || (cliente.RUC.Length>0 && cliente.RUC == beCliente.RUC)).FirstOrDefaultAsync();
            return clientes;
        }

        public async Task<IEnumerable<beCliente>> GetClienteByRUC(string ruc)
        {
            var clientes = await _cliente.Find(cliente => cliente.RUC==ruc).ToListAsync();
            return clientes;
        }
    }
}
