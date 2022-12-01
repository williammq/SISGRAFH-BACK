using AutoMapper;
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
        private static ISolicitudService _solicitudService;
        private static IMapper _mapper;
        public ReporteProduccionController(IOrden_TrabajoService orden_TrabajoService, IReporteProduccionService reporteProduccionService, IMapper mapper, ISolicitudService solicitudService)
        {
            _reporteProduccionService = reporteProduccionService;
            _orden_TrabajoService = orden_TrabajoService;
            _solicitudService = solicitudService;
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
            try
            {
                var reportes = await _reporteProduccionService.GetReportesProduccionById_Ot(reporteProduccionDto.id_orden_trabajo);
                var hayReportes = reportes.Count() > 0;
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("UpdateReporteProduccion")]
        public async Task<IActionResult> UpdateReporteProduccion(ReporteProduccionDto reporteProduccionDto)
        {
            var ot = await _orden_TrabajoService.GetOrdenById(reporteProduccionDto.id_orden_trabajo);
            var sol = await _solicitudService.GetSolicitudById(ot.id_solicitud);
            var ots = await _orden_TrabajoService.GetOrdenesByCodigoCotizacion(sol.codigo_cotizacion);
            //var finalizo = ot.instrucciones.ToArray()[ot.instrucciones.Count()-1].numero_orden==reporteProduccionDto.numero_instruccion && reporteProduccionDto.estado=="Finalizado";
            String id_usuario = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "iduser")?.Value;
            reporteProduccionDto.id_usuario = id_usuario;
            if (reporteProduccionDto.estado == "Finalizado" && ot.instrucciones[ot.instrucciones.Count() - 1].numero_orden == reporteProduccionDto.numero_instruccion)
            {
                ot.estado = "Finalizado"; await _orden_TrabajoService.UpdateOrden(ot);
            }
            //if (sol.productos.Count() == ots.Where(x => x.estado == "Finalizado").Count())
            //{

            //}
            //if (!finalizo)
            //{
            //    ot.estado = "En proceso";
            //    await _orden_TrabajoService.UpdateOrden(ot);
            //}
            var reporte = _mapper.Map<beReporteProduccion>(reporteProduccionDto);
            var reportePosted = await _reporteProduccionService.UpdateReporteProduccion(reporte);
            var response = new ApiResponse<beReporteProduccion>(reportePosted);
            return Ok(response);
        }
    }
}
