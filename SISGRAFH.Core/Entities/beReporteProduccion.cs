using MongoDB.Bson.Serialization.Attributes;
using SISGRAFH.Core.Utils.MongoDbParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Entities
{
    [BsonCollection(MongoCollectionNames.Reporte_Produccion)]
    public class beReporteProduccion:BaseEntity
    {
        [BsonElement("id_orden_trabajo")]
        public string id_orden_trabajo { get; set; }
        [BsonElement("id_maquina")]
        public string id_maquina { get; set; }
        [BsonElement("id_usuario")]
        public string id_usuario { get; set; }
        [BsonElement("fecha_hora_inicio")]
        public DateTime fecha_hora_inicio { get; set; }
        [BsonElement("fecha_hora_fin")]
        public DateTime fecha_hora_fin { get; set; }
        [BsonElement("estado")]
        public string estado { get; set; }
        [BsonElement("entrada")]
        public beComponente entrada { get; set; }
        [BsonElement("salida")]
        public beComponente salida { get; set; }
        [BsonElement("insumos_usados")]
        public List<beInsumoProduccion> insumos_usados { get; set; }
    }
    public class beInsumoProduccion
    {
        [BsonElement("id_insumo")]
        public string id_insumo { get; set; }
        [BsonElement("cantidad_usada")]
        public double cantidad_usada { get; set; }
    }
}
