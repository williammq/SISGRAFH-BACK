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
    [BsonCollection(MongoCollectionNames.Maquinas)]
    [BsonKnownTypes(typeof(beImpresoraDigital), typeof(beLaminadora), typeof(beGuillotina), typeof(beTroqueladora),typeof(bePerforador),typeof(beHendidora))]
    public class beMaquina : BaseEntity
    {
        [BsonElement("codigo")]
        public string codigo { get; set; }
        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("descripcion")]
        public string descripcion { get; set; }
        [BsonElement("url_imagen")]
        public string url_imagen { get; set; }
        [BsonElement("marca")]
        public string marca { get; set; }
        [BsonElement("tipo_maquina")]
        public string tipo_maquina { get; set; }
    }
    public class beArea
    {
        [BsonElement("ancho")]
        public double ancho { get; set; }
        [BsonElement("largo")]
        public double largo { get; set; }
        [BsonElement("unidad_medida")]
        public string unidad_medida { get; set; }
    }
    public class beVolumen
    {
        [BsonElement("ancho")]
        public double ancho { get; set; }
        [BsonElement("largo")]
        public double largo { get; set; }
        [BsonElement("grosor")]
        public double grosor { get; set; }
        [BsonElement("unidad_medida")]
        public string unidad_medida { get; set; }
    }
    public class beFuncioPerforacion
    {
        // 2:1, 3:1, 12:1, etc esto indica el número de agujeros en 1 pulgada
        [BsonElement("paso_perforacion")]
        public bool paso_perforacion { get; set; }
        [BsonElement("numero_pines")]
        public int numero_pines { get; set; }
        //Solo hay 2, redondo(true) y cuadrado(false)
        [BsonElement("tipo_agujero")]
        public bool tipo_agujero { get; set; }
        //Si es redondo
        [BsonElement("diametro_agujero")]
        public double diametro_agujero { get; set; }
        //Si es cuadrado
        [BsonElement("area_agujero")]
        public beArea area_agujero { get; set; }
    }
    //-----------------------------------------------------------------------
    public class beImpresoraDigital : beMaquina
    {
        [BsonElement("area_maxima_hoja")]
        public beArea area_maxima_hoja { get; set; }
        [BsonElement("area_minima_hoja")]
        public beArea area_minima_hoja { get; set; }
        [BsonElement("modelo")]
        public string modelo { get; set; }
        [BsonElement("serie")]
        public string serie { get; set; }
        // Paginas Por Miuto (PPM)
        [BsonElement("velocidad_BN")]
        public int velocidad_BN { get; set; }
        [BsonElement("velocidad_color")]
        public int velocidad_color { get; set; }
        //Inyección de tinta o laser
        [BsonElement("tipo")]
        public string tipo { get; set; }
        [BsonElement("tipos_soporte")]
        public List<string> tipos_soporte { get; set; }
    }
    
    public class bePerforador : beMaquina
    {
        [BsonElement("ancho_perforacion")]
        public double ancho_perforacion { get; set; }
        [BsonElement("modos_perforacion")]
        public List<beFuncioPerforacion> modos_perforacion { get; set; }
        [BsonElement("espesor_perforado")]
        public double espesor_perforado { get; set; }
    }
    public class beGuillotina : beMaquina
    {
        [BsonElement("longitud_corte")]
        public double longitud_corte { get; set; }
        [BsonElement("altura_corte")]
        public double altura_corte { get; set; }
    }
    public class beTroqueladora : beMaquina
    {
        // milimetros
        [BsonElement("capacidad")]
        public double capacidad { get; set; }
        //R3 ,R4,R5,R6,D6,etc
        [BsonElement("cuchilla")]
        public string cuchilla { get; set; }
    }
    public class beLaminadora : beMaquina
    {
        [BsonElement("grosor_laminacion_maximo")]
        public double grosor_laminacion_maximo { get; set; }
        // mm/min
        [BsonElement("velocidad")]
        public double velocidad { get; set; }
        // en milimetros
        [BsonElement("ancho_maximo_laminacion")]
        public double ancho_maximo_laminacion { get; set; }
    }
    public class beHendidora : beMaquina
    {
        // en milimetros
        [BsonElement("profundidad_plegado")]
        public double profundidad_plegado { get; set; }
        [BsonElement("ancho_maximo_plegado")]
        public double ancho_maximo_plegado { get; set; }
    }
}
