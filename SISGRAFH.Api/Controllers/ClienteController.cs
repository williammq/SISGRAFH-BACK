
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        

    }
}
