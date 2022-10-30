using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using System.Threading.Tasks;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        
        private static ITrabajadorService _trabajadorService;
        public TrabajadorController(ITrabajadorService trabajadorService)
        {
            _trabajadorService = trabajadorService;
        }
        [HttpGet("GetAllTrabajadores")]
        public async Task<IActionResult> GetAllTrabajadores()
        {
            var trabajadores = await _trabajadorService.GetAllTrabajadores();
            return Ok(trabajadores);
        }
        [HttpPost("InsertTrabajador")]
        public async Task<IActionResult> InsertTrabajador(beTrabajador _beTrabajador)
        {
            var trabajadores = await _trabajadorService.InsertTrabajador(_beTrabajador);
            return Ok(trabajadores);
        }
        [HttpPut("UpdateTrabajador")]
        public async Task <IActionResult> UpdateTrabajador(beTrabajador _beTrabajador)
        {
            var trabajadores = await _trabajadorService.UpdateTrabajador(_beTrabajador);
            return Ok(trabajadores);
        }

    }
}
