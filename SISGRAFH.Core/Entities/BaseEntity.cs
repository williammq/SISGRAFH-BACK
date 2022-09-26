using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("_audith")]
        public Audith AudithObject { get; set; }
    }

    public class Audith
    {
        [BsonElement("id_usuario_creacion")]
        public string IdUsuarioCreacion { get; set; }
        [BsonElement("usuario_creacion")]
        public string UsuarioCreacion { get; set; }
        [BsonElement("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.MinValue;
        [BsonElement("modificaciones")]
        public List<AudithModifications> Modificaciones { get; set; } = new List<AudithModifications>();
    }
    public class AudithModifications
    {
        [BsonElement("id_usuario")]
        public string IdUsuario { get; set; }
        [BsonElement("nombre_usuario")]
        public string NombreUsuario { get; set; }
        [BsonElement("fecha_modificacion")]
        public DateTime FechaModificacion { get; set; } = DateTime.MinValue;
    }


}
