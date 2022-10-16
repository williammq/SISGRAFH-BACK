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
    [BsonCollection(MongoCollectionNames.Movimientos)]
    public class beMovimiento : BaseEntity
    {
        [BsonElement("cantidad")]
        public int cantidad { get; set; }
        [BsonElement("codigo")]
        public string codigo { get; set; }
        [BsonElement("tipo")]
        public string tipo { get; set; }
        [BsonElement("origen")]
        public beOrigen origen { get; set; }
        [BsonElement("destino")]
        public beDestino destino { get; set; }
        [BsonElement("insumo")]
        public List<beMovimientoInsumo> insumo { get; set; }
        [BsonElement("transporte")]
        public beTransporte transporte { get; set; }
        [BsonElement("estado")]
        public string estado { get; set; }
        [BsonElement("fecha_movimiento")]
        public DateTime fecha_movimiento { get; set; } = DateTime.Now;
    }
    public class beOrigenDestino
    {
        [BsonElement("ubigeo")]
        public string ubigeo { get; set; }
        [BsonElement("direccion")]
        public string direccion { get; set; }
        [BsonElement("local")]
        public string local { get; set; }
    }
    public class beOrigen : beOrigenDestino
    {
        [BsonElement("emisor")]
        public string emisor { get; set; }
    }
    public class beDestino : beOrigenDestino
    {
        [BsonElement("receptor")]
        public string receptor { get; set; }

    }
    public class beTransporte
    {
        [BsonElement("transportista")]
        public string transportista { get; set; }
        [BsonElement("marca_vehiculo")]
        public string marca_vehiculo { get; set; }
        [BsonElement("placa_vehiculo")]
        public string placa_vehiculo { get; set; }
    }
    public class beMovimientoInsumo
    {
        [BsonElement("codigo_insumo")]
        public string codigo_insumo { get; set; }
        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("cantidad")]
        public int cantidad { get; set; }
    }
}
