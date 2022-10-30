using MongoDB.Bson.Serialization.Attributes;
using SISGRAFH.Core.Utils.MongoDbParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Entities
{
    [BsonCollection(MongoCollectionNames.Trabajadores)]
    public class beTrabajador : BaseEntity
    {
        [BsonElement("nombres")]
        public string Nombres { get; set; }

        [BsonElement("apellido_paterno")]
        public string ApellidoPaterno { get; set; }


        [BsonElement("apellido_materno")]
        public string ApellidoMaterno { get; set; }

        [BsonElement("correo")]
        public string Correo { get; set; }

        [BsonElement("telefono")]
        public string Telefono { get; set; }

        [BsonElement("fecha_nacimiento")]
        public string FechaNacimiento { get; set; }

        [BsonElement("foto")]
        public string Foto { get; set; }

        [BsonElement("estado")]
        public string Estado { get; set; }

        [BsonElement("id_usuario")]
        public string IdUsuario { get; set; }

        [BsonElement("documento_identificador")]
        public DocumentoIdentificador DocumentoIdentificador { get; set; }

        
    }
    public class DocumentoIdentificador
    {
        [BsonElement("tipo_documento")]
        public string TipoDocumento { get; set; }

        [BsonElement("numero_documento")]
        public string NumeroDocumento { get; set; }
    }
        
    
}
