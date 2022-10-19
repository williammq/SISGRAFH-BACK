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
        Task<beCliente> GetClienteById(string id);
        Task<beCliente> UpdateCliente(beCliente _beCliente);
        Task<beCliente> InsertCliente (beCliente _beCliente);
        Task<beCliente> GetClienteByNombreApellido(string nombre, string apellidopaterno, string apellidomaterno);

    }
}
