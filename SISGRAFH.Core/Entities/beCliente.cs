using MongoDB.Bson.Serialization.Attributes;
using SISGRAFH.Core.Utils.MongoDbParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Entities
{
    [BsonCollection(MongoCollectionNames.Clientes)]
    public class beCliente : BaseEntity
    {
        [BsonElement("id_usuario")]
        public string IdUsuario { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("apellido_paterno")]
        public string ApellidoPaterno { get; set; }

        [BsonElement("apellido_materno")]
        public string ApellidoMaterno { get; set; }

        [BsonElement("correo")]
        public string Correo { get; set; }

        [BsonElement("telefono")]
        public string Telefono { get; set; }

        [BsonElement("direccion")]
        public string Direccion { get; set; }

        [BsonElement("id_historial_pedidos")]
        public string IdHistorialPedidos { get; set; }

    }
}
