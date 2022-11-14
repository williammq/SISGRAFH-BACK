
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController:ControllerBase
    {
        private static IClienteService _clienteService;
        private static IUsuarioService _usuarioService;

        public ClienteController(IClienteService clienteService, IUsuarioService usuarioService)
        {
            _clienteService = clienteService;
            _usuarioService = usuarioService;
           
        }
        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clienteService.GetAllClientes();
            return Ok(clients);
        }
        [HttpGet("GetClientsByCorreo")]
        public async Task<IActionResult> GetClienteByCorreo(string correo)
        {
            var clients = await _clienteService.GetClienteByCorreo(correo);
            return Ok(clients); 
        }
        [HttpGet("GetClientsById")]
        public async Task<IActionResult> GetClientsId(string id)
        {
            var clients = await _clienteService.GetClienteById(id);
            return Ok(clients);
        }
        [HttpGet("GetClientsByNombreApellido")]
        public async Task<IActionResult> GetClienteByNombreApellido(string nombre,string apellidopaterno, string apellidomaterno)
        {
            var clients = await _clienteService.GetClienteByNombreApellido(nombre,apellidopaterno,apellidomaterno);
            return Ok(clients);
        }

        [HttpGet("GetClientsByNumeroDocumento")]
        public async Task <IActionResult> GetClienteByNumeroDocumento (string numeroDocumento)
        {
            var clients = await _clienteService.GetClienteByNumeroDocumento(numeroDocumento);
            return Ok(clients);
        }
        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateCliente(beCliente _beCliente)
        {
            var clients = await _clienteService.UpdateCliente(_beCliente);
            return Ok(clients);
        }

        [HttpPost("InsertClient")]
        public async Task<IActionResult> InsertCliente(beCliente _beCliente, string clave)
        {
            var usuarioExistente = await _clienteService.GetClienteByCorreo(_beCliente.Correo);
            var usuarioExistente_documento = await _clienteService.GetClienteByNumeroDocumento(_beCliente.NumeroDocumento);
            if (usuarioExistente != null || usuarioExistente_documento!=null)
            {
                //var response = new ApiResponse<IEnumerable<beCliente>>(usuarioExistente);
                return BadRequest("Usuario ya registrado, intente con otro correo o N° de documento");
            }
            else
            {
                var id_cliente = ObjectId.GenerateNewId();
                beUsuario _beUsuario = new beUsuario();

                //Creación de usuario.
                _beUsuario.TipoUsuario = new ObjTipoUsuario { IdUsuario = id_cliente.ToString(), Tipo = "Cliente" };
                _beUsuario.correo_usuario = _beCliente.Correo;
                _beUsuario.Estado = "Activo";
                _beUsuario.Clave = clave;
                _beUsuario.NombreUsuario = _beCliente.Nombre;
                List<ObjRol> roles = new List<ObjRol>();
                roles.Add(new ObjRol { IdRol = "6367535efa43cf529aad6e0e", Nombre = "Cliente" });

                _beUsuario.Roles = roles;
                _beCliente.Id = id_cliente.ToString();
                var usuarios = await _usuarioService.PostUsuario(_beUsuario);
                _beCliente.IdUsuario = usuarios.Id;
                var clients = await _clienteService.InsertCliente(_beCliente);
                return Ok(clients);
            }            
        }

        [HttpGet("GetClientsByRuc")]
        public async Task <IActionResult> GetClienteByRUC(string ruc)
        {
            var clients = await _clienteService.GetClienteByRUC(ruc);
            return Ok(clients);
        }
    }
}
