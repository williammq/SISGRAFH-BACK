using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
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
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var cotizaciones = await _productoService.GetProductos();
            var response = new ApiResponse<IEnumerable<beProducto>>(cotizaciones);
            return Ok(response);
        }
    }
}
