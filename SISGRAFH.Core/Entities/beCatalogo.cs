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
        [BsonElement("tamanios")]
        public List<beTamanioHoja> tamanios { get; set; }
        [BsonElement("tipos_hoja")]
        public List<string> tipos_hoja { get; set; }
        [BsonElement("estadoProducto")]
        public bool estadoProducto { get; set; }
    }

    public class beTamanioHoja{
         [BsonElement("largo")]
        public double largo{ get; set; }
         [BsonElement("ancho")]
        public double ancho{ get; set; }
         [BsonElement("nombreTamanio")]
        public double nombreTamanio{ get; set; }



    }
  
    
}
