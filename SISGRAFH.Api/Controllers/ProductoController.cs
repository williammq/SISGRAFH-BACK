using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.Producto;
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
    public class ProductoController : ControllerBase
    {
        private static IProductoService _productoService;
        private static IMapper _mapper;
        public ProductoController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }
        [HttpGet("GetProductos")]
        public async Task<IActionResult> GetProductos()
        {
            var cotizaciones = await _productoService.GetProductos();
            var response = new ApiResponse<IEnumerable<beProducto>>(cotizaciones);
            return Ok(response);
        }
        [HttpGet("GetProductosCatalogo")]
        public async Task<IActionResult> GetProductosCatalogo()
        {
            var cotizaciones = await _productoService.GetProductosCatalogo();
            var response = new ApiResponse<IEnumerable<beProducto>>(cotizaciones);
            return Ok(response);
        }
        [HttpGet("GetProductoById")]
        public async Task<IActionResult> GetProductoById(string id)
        {
            var producto = await _productoService.GetProductoById(id);
            var response = new ApiResponse<beProducto>(producto);
            return Ok(response);
        }
        [HttpPost("PostProducto")]
        public async Task<IActionResult> PostProducto(ProductoDto productoDto)
        {
            var producto = _mapper.Map<beProducto>(productoDto);
            var productoPosted = await _productoService.PostProducto(producto);

            productoDto = _mapper.Map<ProductoDto>(productoPosted);
            var response = new ApiResponse<ProductoDto>(productoDto);
            return Ok(response);

        }
        [HttpPut("UpdateProducto")]
        public async Task<IActionResult> UpdateProducto(ProductoDto productoDto)
        {
            var producto = _mapper.Map<beProducto>(productoDto);
            var productoPosted = await _productoService.UpdateProducto(producto);

            productoDto = _mapper.Map<ProductoDto>(productoPosted);
            var response = new ApiResponse<ProductoDto>(productoDto);
            return Ok(response);

        }
    }
}
