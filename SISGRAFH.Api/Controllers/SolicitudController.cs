using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private static ISolicitudService _solicitudService;
        private static IMapper _mapper;
        public SolicitudController(ISolicitudService solicitudService, IMapper mapper)
        {
            _solicitudService = solicitudService;
            _mapper = mapper;
        }
        [HttpGet("GetSolicitudes")]
        public async Task<IActionResult> GetSolicitudes()
        {
            var solicitudes = await _solicitudService.GetSolicitudes();
            var response = new ApiResponse<IEnumerable<object>>(solicitudes);
            return Ok(response);
        }
        [HttpGet("GetProductosBySolicitud")]
        public async Task<IActionResult> GetProductosBySolicitud(string id)
        {
            var solicitudes = await _solicitudService.GetProductosBySolicitud(id);
            var response = new ApiResponse<IEnumerable<object>>(solicitudes);
            return Ok(response);
        }
    }
}
