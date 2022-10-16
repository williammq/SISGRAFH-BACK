using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.Movimiento;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private static IMovimientoService _movimientoService;
        private static IMapper _mapper;

        public MovimientoController(IMovimientoService movimientoService, IMapper mapper)
        {
            _movimientoService = movimientoService;
            _mapper = mapper;
        }
        [HttpGet("GetMovimientos")]
        public async Task<IActionResult> GetMovimientos()
        {
            var movimientos = await _movimientoService.GetMovimiento();
            var response = new ApiResponse<IEnumerable<object>>(movimientos);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostMaquina(MovimientoDto movimientoDto)
        {
            var movimiento = _mapper.Map<beMovimiento>(movimientoDto);
            var cotizacionPosted = await _movimientoService.PostMovimiento(movimiento);
            var response = new ApiResponse<beMovimiento>(cotizacionPosted);
            return Ok(response);

        }
    }
}
