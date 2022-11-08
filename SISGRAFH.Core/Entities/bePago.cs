using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SISGRAFH.Core.Utils.MongoDbParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Entities
{
       [BsonCollection(MongoCollectionNames.Pagos)]
   public class bePago : BaseEntity
    {
        
            [BsonElement("Id_cliente")]
            public string Id_cliente { get; set; }
            [BsonElement("monto_pagado")]
            public double monto_pagado{ get; set; }
            [BsonElement("url_imagen")]
            public string url_imagen { get; set; }           
            public string estado { get; set; }
            [BsonElement("motivo_rechazo")]
            public string motivo_rechazo { get; set; }
             [BsonElement("codigo_cotizacion")]
            public string codigo_cotizacion { get; set; }
    }
}
