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
using SISGRAFH.Core.DTOs.Insumo;

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
        [HttpGet("GetInsumos")]
        public async Task<IActionResult> GetInsumos()
        {
            var insumos = await _insumoService.GetInsumos();
            var response = new ApiResponse<IEnumerable<object>>(insumos);
            return Ok(response);
        }
        [HttpPost("PostInsumo")]
        public async Task<IActionResult> PostInsumo(JsonElement JSinsumo)
        {
            string js = JSinsumo.ToString();
            var insumoDto = JsonSerializer.Deserialize<InsumoDto>(js);
            switch (insumoDto.categoria)
            {
                case "Espiral": insumoDto = JsonSerializer.Deserialize<EspiralDto>(js); break;
                case "Tinta": insumoDto = JsonSerializer.Deserialize<TintaDto>(js); break;
                case "Soporte de Impresión": insumoDto = JsonSerializer.Deserialize<PapelDto>(js); break;
                case "Pelicula": insumoDto = JsonSerializer.Deserialize<Pelicula_adhesivaDto>(js); break;
            }
            var insumo = new beInsumo();
            switch (insumoDto.categoria)
            {
                case "Espiral": insumo = _mapper.Map<beEspiral>(insumoDto); break;
                case "Tinta": insumo = _mapper.Map<beTinta>(insumoDto); break;
                case "Soporte de Impresión": insumo = _mapper.Map<bePapel>(insumoDto); ; break;
                case "Pelicula": insumo = _mapper.Map<bePelicula_adhesiva>(insumoDto); ; break;
            }
            var insumoPosted = await _insumoService.PostInsumo(insumo);

            var response = new ApiResponse<beInsumo>(insumoPosted);
            return Ok(response);
        }
        [HttpGet("GetInsumoById")]
        public async Task<IActionResult> GetInsumoById(string id)
        {
            var insumo = await _insumoService.GetInsumoById(id);
            var response = new ApiResponse<object>(insumo);
            return Ok(response);
        }

        [HttpPut("UpdateInsumo")]
        public async Task<IActionResult> UpdateInsumo(JsonElement JSinsumo)
        {
            string js = JSinsumo.ToString();
            var insumoDto = JsonSerializer.Deserialize<InsumoDto>(js);
            switch (insumoDto.categoria)
            {
                case "Espiral": insumoDto = JsonSerializer.Deserialize<EspiralDto>(js); break;
                case "Tinta": insumoDto = JsonSerializer.Deserialize<TintaDto>(js); break;
                case "Soporte de Impresión": insumoDto = JsonSerializer.Deserialize<PapelDto>(js); break;
                case "Pelicula": insumoDto = JsonSerializer.Deserialize<Pelicula_adhesivaDto>(js); break;
            }
            var insumo = new beInsumo();
            switch (insumoDto.categoria)
            {
                case "Espiral": insumo = _mapper.Map<beEspiral>(insumoDto); break;
                case "Tinta": insumo = _mapper.Map<beTinta>(insumoDto); break;
                case "Soporte de Impresión": insumo = _mapper.Map<bePapel>(insumoDto); ; break;
                case "Pelicula": insumo = _mapper.Map<bePelicula_adhesiva>(insumoDto); ; break;
            }

            var insumoPosted = await _insumoService.UpdateInsumo(insumo);
            var response = new ApiResponse<beInsumo>(insumoPosted);
            return Ok(response);
        }

        [HttpGet("GetInsumoByCategoria")]
        public async Task<IActionResult> GetInsumoByCategoria(string categoria)
        {
            var insumo = await _insumoService.GetInsumoByCategoria(categoria);
            var response = new ApiResponse<IEnumerable<beInsumo>>(insumo);
            return Ok(response);
        }

        [HttpGet("GetInsumosByNombre")]
        public async Task<IActionResult> GetInsumosByNombre(string nombre)
        {
            var insumo = await _insumoService.GetInsumoByNombre(nombre);
            var response = new ApiResponse<beInsumo>(insumo);
            return Ok(response);
        }
    }
}
