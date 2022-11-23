using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.Pago;
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
    public class Orden_TrabajoController : ControllerBase
    {
        private static IOrden_TrabajoService _orden_TrabajoService;
        private static IMapper _mapper;
        public Orden_TrabajoController(IOrden_TrabajoService orden_TrabajoService, IMapper mapper)
        {
            _orden_TrabajoService = orden_TrabajoService;
            _mapper = mapper;
        }
        [HttpPost("GenerarOrdenesByCotizacion")]
        public async Task<IActionResult> GenerarOrdenesByCotizacion(string codigo)
        {
            var ordenes = await _orden_TrabajoService.GenerarOrdenesByCotizacion(codigo);
            var response = new ApiResponse<List<beOrden_Trabajo>>(ordenes);
            return Ok(response);
        }
        [HttpGet("GetAllOrdenes")]
        public async Task<IActionResult> GetAllOrdenes(string codigo)
        {
            var ordenes = await _orden_TrabajoService.GetOrdenes();
            var response = new ApiResponse<IEnumerable<beOrden_Trabajo>>(ordenes);
            return Ok(response);
        }
        [HttpGet("GetOrdenesByCodigoSolicitud")]
        public async Task<IActionResult> GetOrdenesByCodigoSolicitud(string codigo)
        {
            var ordenes = await _orden_TrabajoService.GetOrdenesByCodigoCotizacion(codigo);
            var response = new ApiResponse<IEnumerable<beOrden_Trabajo>>(ordenes);
            return Ok(response);
        }
        [HttpGet("GetOrdenesByidMaquina")]
        public async Task<IActionResult> GetOrdenesByidMaquina(string id_maquina)
        {
            var ordenes = await _orden_TrabajoService.GetOrdenesByIdMaquina(id_maquina);
            var response = new ApiResponse<IEnumerable<beOrden_Trabajo>>(ordenes);
            return Ok(response);
        }
    }
}
