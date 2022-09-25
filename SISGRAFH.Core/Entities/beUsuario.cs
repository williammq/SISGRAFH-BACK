using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Entities
{
    [BsonIgnoreExtraElements]
    public class beUsuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nombre_usuario")]
        public string NombreUsuario { get; set; }
        [BsonElement("clave")]
        public string Clave { get; set; }
        [BsonElement("tipo_usuario")]
        public ObjTipoUsuario TipoUsuario { get; set; }
        [BsonElement("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.MinValue;
        [BsonElement("estado")]
        public string Estado { get; set; }
        [BsonElement("roles")]
        public List<ObjRol> Roles { get; set; }
    }

    public class ObjTipoUsuario
    {
        [BsonElement("id_usuario")]
        public string IdUsuario { get; set; }
        [BsonElement("tipo")]
        public string Tipo { get; set; }
    }
    public class ObjRol
    {
        [BsonElement("id_rol")]
        public string IdRol { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
    }
}
