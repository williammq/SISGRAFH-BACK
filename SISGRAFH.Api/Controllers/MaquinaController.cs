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

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaController : ControllerBase
    {
        private static IMaquinaService _maquinaService;
        private static IMapper _mapper;
        public MaquinaController(IMaquinaService maquinaService, IMapper mapper)
        {
            _maquinaService = maquinaService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetMaquinas()
        {
            var maquinas = await _maquinaService.GetMaquinas();
            var response = new ApiResponse<IEnumerable<beMaquina>>(maquinas);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostMaquina(beMaquina maquina)
        {
            var maquinaPosted = await _maquinaService.PostMaquina(maquina);

            var response = new ApiResponse<beMaquina>(maquinaPosted);
            return Ok(response);

        }

    }
}
