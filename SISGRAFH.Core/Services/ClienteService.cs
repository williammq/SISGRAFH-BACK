using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Services
{
    public class ClienteService : IClienteService

    {
        private static IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<beCliente>> GetAllClientes()
        {
            return await _unitOfWork.Cliente.GetAllAsync();
        }

        public async Task<IEnumerable<beCliente>> GetClienteByCorreo(string correo)
        {
            return await _unitOfWork.Cliente.GetClienteByCorreo(correo);
        }
        public async Task<beCliente> GetClienteById(string id)
        {
            return await _unitOfWork.Cliente.GetByIdAsync(id);
        }

        public async Task<IEnumerable<beCliente>> GetClienteByNombreApellido(string nombre, string apellidopaterno, string apellidomaterno)
        {
            return await _unitOfWork.Cliente.GetClienteByNombreApellido(nombre,apellidopaterno,apellidomaterno); 
        }

        public async Task<IEnumerable<beCliente>> GetClienteByNumeroDocumento(string numeroDocumento)
        {
            return await _unitOfWork.Cliente.GetClienteByNumeroDocumento(numeroDocumento);
        }

        public async Task<beCliente> GetClienteByProperty(beCliente beCliente)
        {
            return await _unitOfWork.Cliente.GetClienteByProperty(beCliente);
        }

        public async Task<IEnumerable<beCliente>> GetClienteByRUC(string ruc)
        {
            return await _unitOfWork.Cliente.GetClienteByRUC(ruc);
        }

        public async Task<beCliente> InsertCliente(beCliente _beCliente)
        {
            return await _unitOfWork.Cliente.InsertOneAsync(_beCliente);
        }

        public async Task<beCliente> UpdateCliente(beCliente _beCliente)
        {
            return await _unitOfWork.Cliente.UpdateOneAsync(_beCliente);
        }

    }
}
