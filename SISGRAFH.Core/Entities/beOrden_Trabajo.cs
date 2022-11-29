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
    [BsonCollection(MongoCollectionNames.Orden_Trabajo)]
    public class beOrden_Trabajo : BaseEntity
    {
        [BsonElement("id_producto")]
        public string id_producto { get; set; }
        [BsonElement("codigo")]
        public string codigo { get; set; }
        [BsonElement("codigo_producto")]
        public string codigo_producto { get; set; }
        [BsonElement("id_solicitud")]
        public string id_solicitud { get; set; }
        //En cola, En produccion,Finalizado
        [BsonElement("estado")]
        public string estado { get; set; }
        [BsonElement("instrucciones")]
        public List<beLocalizacion> instrucciones { get; set; }
    }
}
