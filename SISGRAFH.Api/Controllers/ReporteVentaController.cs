using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.ReporteVenta;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using SISGRAFH.Core.Utils.BlobStorage;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteVentaController : ControllerBase
    {
        private static IReporteVentaService _ReporteventaService;
        private static IMapper _mapper;
        public ReporteVentaController(IReporteVentaService ReporteventaService, IMapper mapper)
        {
            _ReporteventaService = ReporteventaService;
            _mapper = mapper;
        }

        [HttpGet("getReporteVenta")]
        public async Task<IActionResult> GetReporteVenta()
        {
            var Reporteventa = await _ReporteventaService.consulventa();
            var response = new ApiResponse<IEnumerable<beReporteVenta>>(Reporteventa);
            return Ok(response);

        }
    }
}
