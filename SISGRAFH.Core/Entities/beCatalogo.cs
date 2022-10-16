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
     [BsonCollection(MongoCollectionNames.Catalogo)]
    public class beCatalogo : BaseEntity
    {
        [BsonElement("id_producto")]
        public string idProducto { get; set; }
        [BsonElement("descripcion")]
        public string descripcionProducto { get; set; }
        [BsonElement("largo")]
        public double largo{ get; set; }
         [BsonElement("ancho")]
        public double ancho{ get; set; }
        
    }
  
    
}
