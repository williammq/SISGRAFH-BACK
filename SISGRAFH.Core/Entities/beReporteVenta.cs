using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SISGRAFH.Core.DTOs.Pago;
using SISGRAFH.Core.Utils.MongoDbParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Entities
{
    [BsonCollection(MongoCollectionNames.Ventas)]
    public class beReporteVenta : BaseEntity
    {

        [BsonElement("id_cliente")]
        public string id_cliente { get; set; }
        [BsonElement("estado")]
        public double estado { get; set; }
        [BsonElement("fecha_de_registro")]
        public string fecha_de_registro { get; set; }
        [BsonElement("reporte")]
        public string reporte { get; set; }
        [BsonElement("pagos")]
        public List<bePago> pagos { get; set; }
        
    }
}
