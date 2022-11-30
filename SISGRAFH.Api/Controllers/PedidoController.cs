
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Core.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;



namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private static IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("GetAll")]
        public async Task <IActionResult> GetAllPedidos()
        {
            var pedidos = await _pedidoService.GetPedidos();
            return Ok(pedidos);
        }
        [HttpGet("GetByCliente")]
        public async Task <IActionResult> GetByCliente(string id)
        {
            var pedidos = await _pedidoService.GetPedidosByCliente(id);
            return Ok(pedidos);
        }

        [HttpGet("GetTrackigPedidosByCliente")]
        public async Task<IActionResult> GetTrackigPedidosByCliente()
        {
            String id_usuario = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "iduser")?.Value;
            var pedidos = await _pedidoService.GetTrackigPedidosByCliente(id_usuario);
            return Ok(pedidos);
        }

        [HttpGet("GetProductoByCliente")]
        public async Task<IActionResult> GetProductoByCliente(string id)
        {
            var pedidos = await _pedidoService.GetProductosByPedido(id);
            return Ok(pedidos);
        }
    }
}

