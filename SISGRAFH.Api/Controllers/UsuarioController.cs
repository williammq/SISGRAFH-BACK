using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.Usuario;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private static IUsuarioService _usuarioService;
        private static IMapper _mapper;
        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        [HttpGet("getUsuario")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usuarioService.GetUsuarios();
            var response = new ApiResponse<IEnumerable<beUsuario>>(users);
            return Ok(response);

        }

        [HttpPost("postUsuario")]
        public async Task<IActionResult> PostUsers(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<beUsuario>(usuarioDto);
            var usuarioPosted = await _usuarioService.PostUsuario(usuario);

            usuarioDto = _mapper.Map<UsuarioDto>(usuarioPosted);
            var response = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(response);

        }

        [HttpPut("putUsuario")]
        public async Task<IActionResult> UpdateUser(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<beUsuario>(usuarioDto);
            var usuarioPosted = await _usuarioService.UpdateUser(usuario);

            usuarioDto = _mapper.Map<UsuarioDto>(usuarioPosted);
            var response = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(response);

        }       
        [HttpPut("Restablecercontraseña")]
        public async Task<IActionResult> Restablecercontraseña(string  correo,string clavenueva)
        {
            var usuario = await _usuarioService.RestablecerContraseña(correo,clavenueva);
            return Ok(usuario);

        }
    }
}
