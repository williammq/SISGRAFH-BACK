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
    [BsonCollection(MongoCollectionNames.Reporte_Merma)]
    public class beReporteMerma:BaseEntity
    {
        [BsonElement("fecha")]
        public DateTime Fecha { get; set; }
        [BsonElement("motivo")]
        public string Motivo { get; set; }
        [BsonElement("insumo")]
        public Objinsumo Insumo { get; set; }
        [BsonElement("trabajador")]
        public Objtrabajador Trabajador { get; set; }
        public string IdReporte { get; set; }
    }

    public class Objinsumo
    {
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("cantidad")]
        public double Cantidad { get; set; }
    }
    public class Objtrabajador
    {
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("apellido_paterno")]
        public string ApellidoPaterno { get; set; }
        [BsonElement("apellido_materno")]
        public string ApellidoMaterno { get; set; }
    }
}
