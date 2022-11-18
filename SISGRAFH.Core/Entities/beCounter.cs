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
    [BsonCollection(MongoCollectionNames.Counter)]
    public class beCounter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("sequence_value")]
        public int sequence_value { get; set; }
        [BsonElement("prefix_code")]
        public string prefix_code { get; set; }
        [BsonElement("separator_left")]
        public string separator_left { get; set; }
        [BsonElement("separator_right")]
        public string separator_right { get; set; }
        [BsonElement("show_pref_code")]
        public bool show_pref_code { get; set; }
        [BsonElement("show_seq_value")]
        public bool show_seq_value { get; set; }
        [BsonElement("reduce_name")]
        public bool reduce_name { get; set; }
        [BsonElement("format_code")]
        public bool format_code { get; set; }
    }

    public class beRpGetCounterName
    {
        public int numberCode { get; set; }
        public string nameWithFormat { get; set; }
    }
}
