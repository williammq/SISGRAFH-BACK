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
    [BsonCollection(MongoCollectionNames.Insumos)]
    [BsonKnownTypes(typeof(beEspiral), typeof(beTinta), typeof(bePapel),typeof(bePelicula_adhesiva))]
    public class beInsumo : BaseEntity
    {
        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("descripcion")]
        public string descripcion { get; set; }
        //Paquete, Rollo, lata, bolsa
        [BsonElement("unidad")]
        public string unidad { get; set; }
        //Hojas,Metros (en caso de rollos de vinil o papel), kg, gr, ml
        [BsonElement("unidad_insumo")]
        public string unidad_insumo { get; set; }
        //50 hojas, 70ml , 1.5 kg ,20 m
        [BsonElement("cantidad_insumo")]
        public double cantidad_insumo { get; set; }
        [BsonElement("categoria")]
        public string categoria { get; set; }
        [BsonElement("marca")]
        public string marca { get; set; }
        [BsonElement("costo_unitario")]
        public double costo_unitario { get; set; }
        [BsonElement("stock_disponible")]
        public int stock_disponible { get; set; }
    }
    public class beEspiral : beInsumo
    {
        [BsonElement("diametro")]
        public double diametro { get; set; }
        [BsonElement("material")]
        public string material { get; set; }
        [BsonElement("longitud")]
        public double longitud { get; set; }
        [BsonElement("grosor_union")]
        public double grosor_union { get; set; }
        [BsonElement("numero_agujeros")]
        public int numero_agujeros { get; set; }
    }
    public class beTinta : beInsumo
    {
        [BsonElement("color")]
        public string color { get; set; }
        //Cuantas paginas rinde
        [BsonElement("rendimiento")]
        public int rendimiento { get; set; }
        //Inyección térmica de tinta y Laser
        [BsonElement("tecnologia_impresion")]
        public string tecnologia_impresion { get; set; }
        //no necesario en offset
        [BsonElement("compatibilidad")]
        public List<string> compatibilidad { get; set; }
    }
    //public class modelo_serie
    //{
    //    public string modelo { get; set; }
    //    public List<string> serie { get; set; }
    //}
    public class bePapel : beInsumo 
    {
        //medidas del papel milimetros
        [BsonElement("ancho")]
        public double ancho { get; set; }
        [BsonElement("largo")]
        public double largo { get; set; }
        // g/m2
        [BsonElement("gramaje")]
        public double gramaje { get; set; }
        [BsonElement("color")]
        public string color { get; set; }
        //couche o estucado mate, semimate, brillante, offset blanco, Cartulina Sulfatada, Bond, cartulina, opalina, kraft, reciclado, vegetal
        [BsonElement("tipo")]
        public string tipo { get; set; }
    }
    public class bePelicula_adhesiva : beInsumo
    {
        //en milimetros
        [BsonElement("ancho")]
        public double ancho { get; set; }
        //normalemente en micras
        [BsonElement("grosor")]
        public double grosor { get; set; }
        //BOPP
        [BsonElement("capa_superficie")]
        public string capa_superficie { get; set; }
        //sello al calor EVA
        [BsonElement("capa_adhesivo")]
        public string capa_adhesivo { get; set; }
        [BsonElement("acabado")]
        public string acabado { get; set; }
    }
    public class bePlacaOffset : beInsumo
    {
        //en milimetros
        [BsonElement("largo")]
        public double largo { get; set; }
        [BsonElement("ancho")]
        public double ancho { get; set; }
        [BsonElement("grosor")]
        public double grosor { get; set; }
        //Alumino, poliester, etc
        [BsonElement("material")]
        public string material { get; set; }
        //Negativo y positivo
        [BsonElement("tipo")]
        public string tipo { get; set; }
        //Luz amarilla, Blanca, etc
        [BsonElement("luz_segura")]
        public string luz_segura { get; set; }
        // medido en mj/cm2
        [BsonElement("sensibilidad_minima")]
        public string sensibilidad_minima { get; set; }
        [BsonElement("sensibilidad_maxima")]
        public string sensibilidad_maxima { get; set; }
        // en segundos
        [BsonElement("tiempo_desarrollo_minimo")]
        public double tiempo_desarrollo_minimo { get; set; }
        [BsonElement("tiempo_desarrollo_maximo")]
        public double tiempo_desarrollo_maximo { get; set; }
    }
}
