using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SISGRAFH.Core.Utils.MongoDbParams;

namespace SISGRAFH.Core.Entities
{
    [BsonCollection(MongoCollectionNames.Pedidos)]
    public class bePedido : BaseEntity
    {
        [BsonElement("id_solicitud")]
        public string id_solicitud { get; set; }
        [BsonElement("id_cliente")]
        public string id_cliente { get; set; }
        [BsonElement("estado")]
        public string estado { get; set; }
        [BsonElement("productos")]
        public List<beProducto_solicitud> productos { get; set; }
    }
}
