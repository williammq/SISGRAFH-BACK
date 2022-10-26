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
    public class MaquinaController : ControllerBase
    {
        private static IMaquinaService _maquinaService;
        private static IMapper _mapper;
        public MaquinaController(IMaquinaService maquinaService, IMapper mapper)
        {
            _maquinaService = maquinaService;
            _mapper = mapper;
        }
        [HttpGet("GetMaquinas")]
        public async Task<IActionResult> GetMaquinas()
        {
            var maquinas = await _maquinaService.GetMaquinas();
            var response = new ApiResponse<IEnumerable<object>>(maquinas);
            return Ok(response);
        }
        [HttpPost("PostMaquina")]
        public async Task<IActionResult> PostMaquina(JsonElement JSONmaquina)
        {
            string js = JSONmaquina.ToString();
            var maquina = JsonSerializer.Deserialize<beMaquina>(js);
            switch (maquina.tipo_maquina)
            {
                case "Impresora": maquina = JsonSerializer.Deserialize<beImpresoraDigital>(js); break;
                case "Guillotina": maquina = JsonSerializer.Deserialize<beGuillotina>(js); break;
                case "Laminadora": maquina = JsonSerializer.Deserialize<beLaminadora>(js); break;
            }
            var maquinaPosted = await _maquinaService.PostMaquina(maquina);

            var response = new ApiResponse<beMaquina>(maquinaPosted);
            return Ok(response);

        }

    }
}
