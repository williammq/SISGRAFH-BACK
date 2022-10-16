using AutoMapper;
using SISGRAFH.Core.DTOs.Cotizacion;
using SISGRAFH.Core.DTOs.Usuario;
using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
