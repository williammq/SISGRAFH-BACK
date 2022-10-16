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

        public async Task<beCliente> GetClienteByCorreo(string id)
        {
            return await _unitOfWork.Cliente.GetByIdAsync(id);
        }
    }
}
