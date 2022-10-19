
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Services;
using System.Threading.Tasks;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController:ControllerBase
    {
        private static IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
           
        }
        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clienteService.GetAllClientes();
            return Ok(clients);
        }
        [HttpGet("GetClientsByCorreo")]
        public async Task<IActionResult> GetClientsCorreo(string correo)
        {
            var clients = await _clienteService.GetClienteByCorreo(correo);
            return Ok(clients);
        }
        [HttpGet("GetClientsById")]
        public async Task<IActionResult> GetClientsId(string id)
        {
            var clients = await _clienteService.GetClienteByCorreo(id);
            return Ok(clients);
        }
        [HttpGet("GetClientsByNombreApellido")]
        public async Task<IActionResult> GetClienteByNombreApellido(string nombre,string apellidopaterno, string apellidomaterno)
        {
            var clients = await _clienteService.GetClienteByNombreApellido(nombre,apellidopaterno,apellidomaterno);
            return Ok(clients);
        }
        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateCliente(beCliente _beCliente)
        {
            var clients = await _clienteService.UpdateCliente(_beCliente);
            return Ok(clients);
        }

        [HttpPost("InsertClient")]
        public async Task <IActionResult> InsertCliente(beCliente _beCliente)
        {
            var clients = await _clienteService.InsertCliente(_beCliente);
            return Ok(clients);
        }

    }
}
