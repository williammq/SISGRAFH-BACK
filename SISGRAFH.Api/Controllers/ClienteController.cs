
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
            var usuarioExistente = await _clienteService.GetClienteByProperty(_beCliente) != null;
            if (usuarioExistente)
            {
                return BadRequest("Cliente YA EXISTENTE!(el correo, telefono, RUC o N° de documento ya fueron registrados antes)");
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
                _beUsuario.Roles.Add(new ObjRol { IdRol = "6367535efa43cf529aad6e0e", Nombre = "Cliente" });
                _beCliente.Id = id_cliente.ToString();
                var usuario = await _usuarioService.PostUsuario(_beUsuario);
                _beCliente.IdUsuario = usuario.Id;
                var client = await _clienteService.InsertCliente(_beCliente);
                return Ok(client);
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
