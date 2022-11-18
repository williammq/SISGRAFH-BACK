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
    public class UbigeoController : ControllerBase
    {
        private static IUbigeoService _ubigeoService;
        public UbigeoController(IUbigeoService ubigeoService)
        {
            _ubigeoService = ubigeoService;
        }
        [HttpGet("GetAllUbigeos")]
        public async Task<List<beUbigeo>> GetAllUbigeos()
        {
            var ubigeos = await _ubigeoService.GetAllUbigeo();
            //var response = new ApiResponse<List<beUbigeo>>(ubigeos);
            return ubigeos;
        }
        [HttpGet("GetByIdUbigeo")]
        public async Task<IActionResult> GetByIdUbigeo(string ubigeo)
        {
            var ubigeos = await _ubigeoService.GetByIdUbigeo(ubigeo);
            return Ok(ubigeos);
        }
    }
}
