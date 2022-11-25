using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.Reporte_Producción;
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
    public class ReporteProduccionController : Controller
    {
        private static IReporteProduccionService _reporteProduccionService;
        private static IOrden_TrabajoService _orden_TrabajoService;
        private static IMapper _mapper;
        public ReporteProduccionController(IOrden_TrabajoService orden_TrabajoService,IReporteProduccionService reporteProduccionService, IMapper mapper)
        {
            _reporteProduccionService = reporteProduccionService;
            _orden_TrabajoService = orden_TrabajoService;
            _mapper = mapper;
        }
        [HttpGet("GetReportesProduccion")]
        public async Task<IActionResult> GetReportesProduccion()
        {
            var reportes = await _reporteProduccionService.GetReportesProduccion();
            var response = new ApiResponse<IEnumerable<beReporteProduccion>>(reportes);
            return Ok(response);
        }
        [HttpPost("PostReporteProduccion")]
        public async Task<IActionResult> PostReporteProduccion(ReporteProduccionDto reporteProduccionDto)
        {
            var reportes = await _reporteProduccionService.GetReportesProduccionById_Ot(reporteProduccionDto.id_orden_trabajo);
            var hayReportes = reportes.Count()>0;
            String id_usuario = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "iduser")?.Value;
            reporteProduccionDto.id_usuario = id_usuario;
            if (!hayReportes)
            {
                var ot = await _orden_TrabajoService.GetOrdenById(reporteProduccionDto.id_orden_trabajo);
                ot.estado = "En proceso";
                await _orden_TrabajoService.UpdateOrden(ot);
            }
            var reporte = _mapper.Map<beReporteProduccion>(reporteProduccionDto);
            var reportePosted = await _reporteProduccionService.PostReporteProduccion(reporte);
            var response = new ApiResponse<beReporteProduccion>(reportePosted);
            return Ok(response);
        }
    }
}
