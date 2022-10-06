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
using System.Text.Json;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoController : ControllerBase
    {
        private static IInsumoService _insumoService;
        private static IMapper _mapper;
        public InsumoController(IInsumoService insumoService, IMapper mapper)
        {
            _insumoService = insumoService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetInsumos()
        {
            var insumos = await _insumoService.GetInsumos();
            var response = new ApiResponse<IEnumerable<object>>(insumos);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostInsumo(JsonElement JSinsumo)
        {
            string js = JSinsumo.ToString();
            var insumo = JsonSerializer.Deserialize<beInsumo>(js);
            switch (insumo.categoria)
            {
                case "Espiral": insumo = JsonSerializer.Deserialize<beEspiral>(js); break;
                case "Tinta": insumo = JsonSerializer.Deserialize<beTinta>(js); break;
                case "Papel": insumo = JsonSerializer.Deserialize<bePapel>(js); break;
                case "Pelicula": insumo = JsonSerializer.Deserialize<bePelicula_adhesiva>(js); break;
            }
            var insumoPosted = await _insumoService.PostInsumo(insumo);

            var response = new ApiResponse<beInsumo>(insumoPosted);
            return Ok(response);

        }
    }
}
