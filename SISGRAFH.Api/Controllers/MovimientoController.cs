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
        [HttpGet("GetAllMovimientos")]
        public async Task<IActionResult> GetAllMovimientos()
        {
            var movimientos = await _movimientoService.GetAllMovimiento();
            var response = new ApiResponse<IEnumerable<object>>(movimientos);
            return Ok(response);
        }
        [HttpGet("GetByIdMovimiento")]
        public async Task<IActionResult> GetByIdMovimiento(string id)
        {
            var movimiento = await _movimientoService.GetByIdMovimiento(id);
            return Ok(movimiento);
        }
        [HttpPost("PostMovimiento")]
        public async Task<IActionResult> PostMMovimiento(MovimientoDto movimientoDto)
        {
            var movimiento = _mapper.Map<beMovimiento>(movimientoDto);
            var cotizacionPosted = await _movimientoService.PostMovimiento(movimiento);
            var response = new ApiResponse<beMovimiento>(cotizacionPosted);
            return Ok(response);

        }
        [HttpPut("UpdateMovimiento")]
        public async Task<IActionResult> UpdateMovimiento(MovimientoDto movimientoDto)
        {
            var movimiento = _mapper.Map<beMovimiento>(movimientoDto);
            var cotizacionPosted = await _movimientoService.UpdateMovimiento(movimiento);

            movimientoDto = _mapper.Map<MovimientoDto>(cotizacionPosted);
            var response = new ApiResponse<MovimientoDto>(movimientoDto);
            return Ok(response);
        }
    }
}
