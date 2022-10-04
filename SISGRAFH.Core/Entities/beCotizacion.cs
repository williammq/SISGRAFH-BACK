using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SISGRAFH.Core.Entities
{
    public class beCotizacion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("id_solicitud")]
        public string id_solicitud { get; set; }
        [BsonElement("codigo_cotizacion")]
        public string codigo_cotizacion { get; set; }
        //Pendiente, En evaluación, Aceptado, Rechazado, Renegociar
        [BsonElement("estado")]
        public string estado { get; set; }
        [BsonElement("fecha_registro")]
        public DateTime fecha_registro { get; set; } = DateTime.Now;
        [BsonElement("fecha_modificacion")]
        public DateTime fecha_modificacion { get; set; } = DateTime.Now;

    }
    public class beLocalizacion
    {
        [BsonElement("id_maquina")]
        public string id_maquina { get; set; }
        [BsonElement("insumos")]
        public List<beInsumoCotizacion> insumos { get; set; }
    }
    public class beInsumoCotizacion
    {
        [BsonElement("id_insumo")]
        public string id_insumo { get; set; }
        [BsonElement("cantidad_requerida")]
        public string cantidad_requerida { get; set; }
    }
}
