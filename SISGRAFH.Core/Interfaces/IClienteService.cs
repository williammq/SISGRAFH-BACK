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
        Task<IEnumerable<beCliente>> GetClienteByCorreo(string correo);
        Task<beCliente> GetClienteById(string id);
        Task<beCliente> UpdateCliente(beCliente _beCliente);
        Task<beCliente> InsertCliente (beCliente _beCliente);
        Task<IEnumerable<beCliente>> GetClienteByNombreApellido(string nombre, string apellidopaterno, string apellidomaterno);
        Task<IEnumerable<beCliente>> GetClienteByNumeroDocumento(string numeroDocumento);

    }   
}
