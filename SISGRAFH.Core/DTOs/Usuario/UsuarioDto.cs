using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISGRAFH.Core.Entities;

namespace SISGRAFH.Core.DTOs.Usuario
{
    //DTO para Insert/Update
    public class UsuarioDto
    {
        public string Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public ObjTipoUsuarioDto TipoUsuario { get; set; }
        public string Estado { get; set; }
        public List<ObjRolDto> Roles { get; set; }
    }

    public class ObjTipoUsuarioDto
    {
        public string IdUsuario { get; set; }
        public string Tipo { get; set; }
    }
    public class ObjRolDto
    {
        public string IdRol { get; set; }
        public string Nombre { get; set; }
    }
}
