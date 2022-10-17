using MongoDB.Bson.Serialization.Attributes;
using SISGRAFH.Core.Utils.MongoDbParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Entities
{
    [BsonCollection(MongoCollectionNames.Productos)]
    public class beProducto : BaseEntity
    {
        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("descripcion")]
        public string descripcion { get; set; }
        [BsonElement("url_imagen")]
        public string url_imagen { get; set; }
    }
}
