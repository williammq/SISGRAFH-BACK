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


namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        
        private static IPagoService _pagoService;
        private static IMapper _mapper;
        public PagoController(IPagoService pagoService, IMapper mapper)
        {
            _pagoService = pagoService;
            _mapper = mapper;
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
    }
}