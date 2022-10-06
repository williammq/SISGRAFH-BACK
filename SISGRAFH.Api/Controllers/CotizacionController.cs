using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.Usuario;
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
        [HttpPost]
        public async Task<IActionResult> PostCotizacion(beCotizacion cotizacion)
        {
            var cotizacionPosted = await _cotizacionService.PostCotizacion(cotizacion);

            var response = new ApiResponse<beCotizacion>(cotizacionPosted);
            return Ok(response);

        }
    }
}
