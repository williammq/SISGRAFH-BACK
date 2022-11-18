using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.Usuario;
using SISGRAFH.Core.DTOs.Cotizacion;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private static ICotizacionService _cotizacionService;
        private static IMapper _mapper;
        public CotizacionController(ICotizacionService cotizacionService, IMapper mapper)
        {
            _cotizacionService = cotizacionService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCotizaciones()
        {
            var cotizaciones = await _cotizacionService.GetCotizaciones();
            var response = new ApiResponse<IEnumerable<beCotizacion>>(cotizaciones);
            return Ok(response);
        }
        [HttpGet("GetCotizacionById")]
        public async Task<IActionResult> GetCotizacionById(string id)
        {
            var cotizacion = await _cotizacionService.GetCotizacionById(id);
            var response = new ApiResponse<beCotizacion>(cotizacion);
            return Ok(response);
        }
        [HttpGet("GetCotizacionByCodigoCotizacion")]
        public async Task<IActionResult> GetCotizacionByCodigoCotizacion(string codigo)
        {
            var cotizacion = await _cotizacionService.GetCotizacionByCodigoCotizacion(codigo,"Enviado");
            var response = new ApiResponse<beCotizacion>(cotizacion);
            return Ok(response);
        }
        [HttpGet("GetCotizacionesByCodigoCotizacion")]
        public async Task<IActionResult> GetCotizacionesByCodigoCotizacion(string codigo)
        {
            var cotizacion = await _cotizacionService.GetCotizacionesByCodigoCotizacion(codigo);
            var response = new ApiResponse<IEnumerable<beCotizacion>>(cotizacion);
            return Ok(response);
        }
        [HttpPost("PostCotizacion")]
        public async Task<IActionResult> PostCotizacion(cotizacionDto cotizacionDTO)
        {
            var cotizacion = _mapper.Map<beCotizacion>(cotizacionDTO);
            var cotizacionPosted = await _cotizacionService.PostCotizacion(cotizacion);
            var response = new ApiResponse<beCotizacion>(cotizacionPosted);
            return Ok(response);
        }

        [HttpPut("UpdateCotizacion")]
        public async Task<IActionResult> UpdateCotizacion(cotizacionDto cotizacionDTO)
        {
            var cotizacion = _mapper.Map<beCotizacion>(cotizacionDTO);
            var cotizacionPosted = await _cotizacionService.UpdateCotizacion(cotizacion);

            cotizacionDTO = _mapper.Map<cotizacionDto>(cotizacionPosted);
            var response = new ApiResponse<cotizacionDto>(cotizacionDTO);
            return Ok(response);
        }
    }
}
