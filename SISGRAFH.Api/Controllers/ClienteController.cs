
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
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clienteService.GetAllClientes();
            return Ok(clients);
        }
        [HttpGet("GetClientsCorreo")]
        public async Task<IActionResult> GetClientsCorreo(string correo)
        {
            var clients = await _clienteService.GetClienteByCorreo(correo);
            return Ok(clients);
        }
        [HttpGet("GetClientsId")]
        public async Task<IActionResult> GetClientsId(string id)
        {
            var clients = await _clienteService.GetClienteByCorreo(id);
            return Ok(clients);
        }
        [HttpPut("UpdateCliente")]
        public async Task<IActionResult> UpdateCliente(beCliente _beCliente)
        {
            var clients = await _clienteService.UpdateCliente(_beCliente);
            return Ok(clients);
        }

        [HttpPost("InsertCliente")]
        public async Task <IActionResult> InsertCliente(beCliente _beCliente)
        {
            var clients = await _clienteService.InsertCliente(_beCliente);
            return Ok(clients);
        }

    }
}
