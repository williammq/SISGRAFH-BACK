using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        
        private static ITrabajadorService _trabajadorService;
        private static IUsuarioService _usuarioService;
        public TrabajadorController(ITrabajadorService trabajadorService, IUsuarioService usuarioService )
        {
            _trabajadorService = trabajadorService;
            _usuarioService = usuarioService;
        }
        [HttpGet("GetAllTrabajadores")]
        public async Task<IActionResult> GetAllTrabajadores()
        {
            var trabajadores = await _trabajadorService.GetAllTrabajadores();
            return Ok(trabajadores);
        }
        [HttpPost("InsertTrabajador")]
        public async Task<IActionResult> InsertTrabajador(beTrabajador _beTrabajador, string clave)
        {
            var id_trabajador = ObjectId.GenerateNewId();
            beUsuario _beUsuario = new beUsuario();

            _beUsuario.NombreUsuario = _beTrabajador.Nombres;
            _beUsuario.TipoUsuario = new ObjTipoUsuario { IdUsuario = id_trabajador.ToString(), Tipo = "Trabajador" };
            _beUsuario.correo_usuario = _beTrabajador.Correo;
            _beUsuario.Estado = "Activo";
            _beUsuario.Clave = clave;

            List<ObjRol> roles = new List<ObjRol>();
            roles.Add(new ObjRol { IdRol = "6367535efa43cf529aad6e0e", Nombre = "Trabajador" });
            _beUsuario.Roles = roles;

            _beTrabajador.Id = id_trabajador.ToString();
            var usuarios = await _usuarioService.PostUsuario(_beUsuario);
            _beTrabajador.IdUsuario = usuarios.Id;
            var trabajadores = await _trabajadorService.InsertTrabajador(_beTrabajador);
            return Ok(trabajadores);
        }
        [HttpPut("UpdateTrabajador")]
        public async Task <IActionResult> UpdateTrabajador(beTrabajador _beTrabajador)
        {
            var trabajadores = await _trabajadorService.UpdateTrabajador(_beTrabajador);
            return Ok(trabajadores);
        }
        [HttpGet("GetTrabajadorById")]
        public async Task <IActionResult> GetTrabajadorById (string id)
        {
            var trabajadores = await _trabajadorService.GetTrabajadorById(id);
            return Ok(trabajadores);
        }
    }
}
