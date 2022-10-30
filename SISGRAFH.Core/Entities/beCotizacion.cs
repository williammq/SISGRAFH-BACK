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
    [BsonCollection(MongoCollectionNames.Cotizaciones)]
    public class beCotizacion : BaseEntity
    {
        [BsonElement("id_solicitud")]
        public string id_solicitud { get; set; }
        [BsonElement("codigo_cotizacion")]
        public string codigo_cotizacion { get; set; }
        //Pendiente, En evaluación, Aceptado, Rechazado, Renegociar
        [BsonElement("estado")]
        public string estado { get; set; }
        //[BsonElement("fecha_registro")]
        //public DateTime fecha_registro { get; set; } = DateTime.Now;
        //[BsonElement("fecha_modificacion")]
        //public DateTime fecha_modificacion { get; set; } = DateTime.Now;
        //Las maquinas por las que debera pasar antes de llegar a ser despachado
        [BsonElement("productos_cotizados")]
        public List<beProductoCotizado> productos_cotizados { get; set; }
    }
    public class beProductoCotizado
    {
        [BsonElement("id_producto")]
        public string id_producto { get; set; }
        [BsonElement("localizaciones")]
        public List<beLocalizacion> localizaciones { get; set; }
    }

    public class beLocalizacion
    {
        [BsonElement("id_maquina")]
        public string id_maquina { get; set; }
        [BsonElement("numero_orden")]
        public int numero_orden { get; set; }
        [BsonElement("insumos")]
        public List<beInsumoCotizacion> insumos { get; set; }
    }
    public class beInsumoCotizacion
    {
        [BsonElement("id_insumo")]
        public string id_insumo { get; set; }
        [BsonElement("costo_unitario_insumo")]
        public double costo_unitario_insumo { get; set; }
        [BsonElement("cantidad_requerida")]
        public string cantidad_requerida { get; set; }
    }
}
