﻿using Microsoft.AspNetCore.Http;
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
using SISGRAFH.Core.Services;
using SISGRAFH.Core.DTOs.Usuario;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {

        private static IPagoService _pagoService;
        private static IOrden_TrabajoService _ordenTrabajoService;
        private static IMapper _mapper;
        public PagoController(IPagoService pagoService, IOrden_TrabajoService ordenTrabajoService, IMapper mapper)
        {
            _pagoService = pagoService;
            _mapper = mapper;
            _ordenTrabajoService = ordenTrabajoService;
        }

        [HttpPost("PagoTP1")]
        public async Task<IActionResult> PostPago(PagoDto pagoDto)
        {
            var pago = _mapper.Map<bePago>(pagoDto);
            var usuarioPosted = await _pagoService.PostPago(pago);

            pagoDto = _mapper.Map<PagoDto>(usuarioPosted);
            var response = new ApiResponse<PagoDto>(pagoDto);
            return Ok(response);

        }


        [HttpPut("Evaluar_Pago")]
        public async Task<IActionResult> evaluarPago(PagoDto evalpagoDto)
        {
            var evalpagos = _mapper.Map<bePago>(evalpagoDto);
            if (evalpagoDto.estado.ToLower() == "aprobado") {await _ordenTrabajoService.GenerarOrdenesByCotizacion(evalpagoDto.codigo_cotizacion); }
            var pagoPosted = await _pagoService.evaluarPago(evalpagos);

            evalpagoDto = _mapper.Map<PagoDto>(pagoPosted);
            var response = new ApiResponse<PagoDto>(evalpagoDto);
            return Ok(response);

        }

        [HttpGet("getPago")]
        public async Task<IActionResult> GetPago()
        {
            var pago = await _pagoService.GetPago();
            var response = new ApiResponse<IEnumerable<bePago>>(pago);
            return Ok(response);

        }

        [HttpGet("GetPagoById")]
        public async Task<IActionResult> GetPagoById(string id)
        {
            var pagoid= await _pagoService.GetPagoById(id);
            var response = new ApiResponse<bePago>(pagoid);
            return Ok(response);
        }

        [HttpPut("putPago")]
        public async Task<IActionResult> UpdateUser(PagoDto modpago)
        {
            var modipago = _mapper.Map<bePago>(modpago);
            var pagoPosted = await _pagoService.ModPago(modipago);

            modpago = _mapper.Map<PagoDto>(pagoPosted);
            var response = new ApiResponse<PagoDto>(modpago);
            return Ok(response);

        }
    }
}
