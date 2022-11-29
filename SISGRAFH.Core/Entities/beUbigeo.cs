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
    [BsonCollection(MongoCollectionNames.Ubigeo)]
    public class beUbigeo: BaseEntity
    {
        [BsonElement("ubigeo")]
        public string ubigeo { get; set; }
        [BsonElement("departamento")]
        public string departamento { get; set; }
        [BsonElement("provincia")]
        public string provincia { get; set; }
        [BsonElement("distrito")]
        public string distrito { get; set; }
    }
}
