using AutoMapper;
using SISGRAFH.Core.DTOs.Catalogo;
using SISGRAFH.Core.DTOs.Cliente;
using SISGRAFH.Core.DTOs.Cotizacion;
using SISGRAFH.Core.DTOs.Insumo;
using SISGRAFH.Core.DTOs.Solicitud;
using SISGRAFH.Core.DTOs.Usuario;
using SISGRAFH.Core.DTOs.Producto;
using SISGRAFH.Core.DTOs.Pago;
using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISGRAFH.Core.DTOs.Orden_Trabajo;

namespace SISGRAFH.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //Automapper de Usuarios
            CreateMap<beUsuario, UsuarioDto>();
            CreateMap<UsuarioDto, beUsuario>();

            CreateMap<ObjRol, ObjRolDto>();
            CreateMap<ObjRolDto, ObjRol>();

            CreateMap<ObjTipoUsuario, ObjTipoUsuarioDto>();
            CreateMap<ObjTipoUsuarioDto, ObjTipoUsuario>();
        

            //Automapper de Cotización
            CreateMap<beCotizacion, cotizacionDto>();
            CreateMap<cotizacionDto, beCotizacion>();

            CreateMap<beLocalizacion, localizacionDto>();
            CreateMap<localizacionDto, beLocalizacion>();

            CreateMap<beInsumoCotizacion, insumoCotizacionDto>();
            CreateMap<insumoCotizacionDto, beInsumoCotizacion>();

            CreateMap<beProductoCotizado, ProductoCotizadoDto>();
            CreateMap<ProductoCotizadoDto, beProductoCotizado>();

            CreateMap<beComponente, componenteDto>();
            CreateMap<componenteDto, beComponente>();
            //Automapper de Insumo
            CreateMap<beInsumo, InsumoDto>();
            CreateMap<InsumoDto, beInsumo>();
            CreateMap<beEspiral, EspiralDto>();
            CreateMap<EspiralDto, beEspiral>();

            CreateMap<beTinta, TintaDto>();
            CreateMap<TintaDto, beTinta>();

            CreateMap<bePapel, PapelDto>();
            CreateMap<PapelDto, bePapel>();

            CreateMap<bePelicula_adhesiva, Pelicula_adhesivaDto>();
            CreateMap<Pelicula_adhesivaDto, bePelicula_adhesiva>();

            CreateMap<bePlacaOffset, PlacaOffsetDto>();
            CreateMap<PlacaOffsetDto, bePlacaOffset>();

            CreateMap<modelo_serie, modelo_serie_Dto>();
            CreateMap<modelo_serie_Dto, modelo_serie>();
            //AutoMapper de solicitud de Cotización
            CreateMap<beSolicitud, SolicitudDto>();
            CreateMap<SolicitudDto, beSolicitud>(); 
            
            CreateMap<beProducto_solicitud, Producto_solicitudDto>();
            CreateMap<Producto_solicitudDto, beProducto_solicitud>();

            CreateMap<beTalonario, TalonarioDto>();
            CreateMap<TalonarioDto, beTalonario>();

            CreateMap<beTarjetaPresentación, TarjetaPresentaciónDto>();
            CreateMap<TarjetaPresentaciónDto, beTarjetaPresentación>();

            CreateMap<beTriptico, TripticoDto>();
            CreateMap<TripticoDto, beTriptico>();

            CreateMap<beDiptico, DipticoDto>();
            CreateMap<DipticoDto, beDiptico>();

            //Automapper de Catalogo
            CreateMap<beCatalogo, CatalogoDto>();
            CreateMap<CatalogoDto, beCatalogo>();

            CreateMap<beTamanioHoja, beTamanioHojaDto>();
            CreateMap<beTamanioHojaDto, beTamanioHoja>();

            //Automapper de Cliente
            CreateMap<beCliente, ClienteDto>();
            CreateMap<ClienteDto, beCliente>();

            //Automapper de Producto
            CreateMap<beProducto, ProductoDto>();
            CreateMap<ProductoDto, beProducto>();

            //Automapper de Orden de Trabajo
            CreateMap<beOrden_Trabajo, Orden_TrabajoDto>();
            CreateMap<Orden_TrabajoDto, beOrden_Trabajo>();

            //Automapper de Pago
            CreateMap<bePago, PagoDto>();
            CreateMap<PagoDto, bePago>();
        }
    }
}
