using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.Catalogo;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private static ICatalogoService _catalogoService;
        private static IMapper _mapper;
        public CatalogoController(ICatalogoService catalogoService, IMapper mapper)
        {
            _catalogoService = catalogoService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCatalogo()
        {
            var catalog = await _catalogoService.GetCatalogo();
            var response = new ApiResponse<IEnumerable<beCatalogo>>(catalogo);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> PostCatalogo(CatalogoDto catalogoDto)
        {
            var catalogo= _mapper.Map<beCatalogo>(catalogoDto);
            var catalogoPosted = await _catalogoService.PostCatalogo(catalogo));

            catalogoDto = _mapper.Map<CatalogoDto>(catalogoPosted);
            var response = new ApiResponse<CatalogoDto>(catalogoDto);
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCatalogo(CatalogoDto catalogoDto)
        {
            var catalogo = _mapper.Map<beCatalogo>(CatalogoDto);
            var catalogoPosted = await _catalogoService.UpdateCatalogo(catalogo);

            catalogoDto = _mapper.Map<CatalogoDto>(catalogoPosted);
            var response = new ApiResponse<CatalogoDto>(catalogoDto);
            return Ok(response);

        }
    }
}
