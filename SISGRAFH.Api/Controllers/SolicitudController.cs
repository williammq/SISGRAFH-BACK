using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.Solicitud;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Hosting;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private static ISolicitudService _solicitudService;
        private static IProductoService _productoService;
        private readonly IHostingEnvironment _enviroment;
        private readonly string contentPath = "";
        private static IMapper _mapper;
        public SolicitudController(IHostingEnvironment environment, IProductoService productoService,ISolicitudService solicitudService, IMapper mapper)
        {
            _solicitudService = solicitudService;
            _productoService = productoService;
            _enviroment = environment;
            _mapper = mapper;
            contentPath = _enviroment.ContentRootPath;
        }
        [HttpGet("GetSolicitudes")]
        public async Task<IActionResult> GetSolicitudes()
        {
            var solicitudes = await _solicitudService.GetSolicitudes();
            var response = new ApiResponse<IEnumerable<object>>(solicitudes);
            return Ok(response);
        }
        [HttpGet("GetProductosBySolicitud")]
        public async Task<IActionResult> GetProductosBySolicitud(string id)
        {
            var solicitudes = await _solicitudService.GetProductosBySolicitud(id);
            var response = new ApiResponse<IEnumerable<object>>(solicitudes);
            return Ok(response);
        }
        [HttpPost("PostSolicitud")]
        public async Task<IActionResult> PostSolicitud(JsonElement JSsolicitud)
        {
            string nombreProducto = "";
            var lst = JObject.Parse(JSsolicitud.ToString())["productos"].ToObject<List<object>>();
            var solicitudDto = JsonSerializer.Deserialize<SolicitudDto>(JSsolicitud.ToString());
            solicitudDto.productos = new List<Producto_solicitudDto>();

            foreach (JObject itemjs in lst)
            {
                string idProducto = itemjs["id_producto"].Value<string>();
                beProducto producto = await _productoService.GetProductoById(idProducto);
                nombreProducto = producto.nombre.ToLower();
                switch (nombreProducto)
                {
                    case "talonario":
                        TalonarioDto t = new TalonarioDto();
                        t = itemjs.ToObject<TalonarioDto>();
                        solicitudDto.productos.Add(t);
                        break;
                    case "tarjeta de presentación":
                        TarjetaPresentaciónDto tp = new TarjetaPresentaciónDto();
                        tp = itemjs.ToObject<TarjetaPresentaciónDto>();
                        solicitudDto.productos.Add(tp);
                        break;
                    case "triptico":
                        TripticoDto tri = new TripticoDto();
                        tri = itemjs.ToObject<TripticoDto>();
                        solicitudDto.productos.Add(tri);
                        break;
                    case "diptico":
                        DipticoDto di = new DipticoDto();
                        di = itemjs.ToObject<DipticoDto>();
                        solicitudDto.productos.Add(di);
                        break;
                    default:
                        Producto_solicitudDto ps = new Producto_solicitudDto();
                        ps = itemjs.ToObject<Producto_solicitudDto>();
                        solicitudDto.productos.Add(ps);
                        break;
                }
            }

            var solicitud = _mapper.Map<beSolicitud>(solicitudDto);
            solicitud.productos = new List<beProducto_solicitud>();

            solicitudDto.productos.ForEach(delegate (Producto_solicitudDto p) {
                string type = p.GetType().Name;
                switch (type)
                {
                    case "TalonarioDto":
                        solicitud.productos.Add(_mapper.Map<beTalonario>(p));
                        break;
                    case "TarjetaPresentaciónDto":
                        TarjetaPresentaciónDto tp = (TarjetaPresentaciónDto)p;
                        solicitud.productos.Add(_mapper.Map<beTarjetaPresentación>(tp));
                        break;
                    case "TripticoDto":
                        solicitud.productos.Add(_mapper.Map<beTriptico>(p));
                        break;
                    case "DipticoDto":
                        solicitud.productos.Add(_mapper.Map<beDiptico>(p));
                        break;
                    default:
                        solicitud.productos.Add(_mapper.Map<beProducto_solicitud>(p));
                        break;
                }
            });
            string GetPath(string base64)
            {
                byte[] arrayBytes = Convert.FromBase64String(base64);
                string id = Guid.NewGuid().ToString();
                string ruta = System.IO.Path.Combine(contentPath, "images", id + ".png");
                System.IO.File.WriteAllBytes(ruta, arrayBytes);
                return ruta;
            }
            solicitud.productos.ForEach(delegate (beProducto_solicitud p) {
                for (int i = 0; i < p.archivos.Count; i++)
                {
                    p.archivos[i] = GetPath(p.archivos[i].Split(',')[1]);
                }
            });
            var solicitudPosted = await _solicitudService.PostSolicitud(solicitud);
            var response = new ApiResponse<beSolicitud>(solicitudPosted);
            return Ok(response);
        }
    }
}
