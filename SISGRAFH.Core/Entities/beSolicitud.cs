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
    [BsonCollection(MongoCollectionNames.Solicitudes)]
    
    public class beSolicitud : BaseEntity
    {
        [BsonElement("nombre_apellidos")]
        public string nombre_apellidos { get; set; }
        [BsonElement("numero_celular")]
        public string numero_celular { get; set; }
        [BsonElement("correo")]
        public string correo { get; set; }
        [BsonElement("fecha_registro")]
        public DateTime fecha_registro { get; set; } = DateTime.Now;
        [BsonElement("codigo_cotizacion")]
        public string codigo_cotizacion { get; set; }
        [BsonElement("estado")]
        public string estado { get; set; }
        [BsonElement("productos")]
        public List<beProducto_solicitud> productos { get; set; }
    }
    [BsonKnownTypes(typeof(beTalonario), typeof(beTarjetaPresentación), typeof(beTriptico), typeof(beDiptico))]
    public class beProducto_solicitud
    {
        [BsonElement("id_producto")]
        public string id_producto { get; set; }
        //4+4 Impresos a todo color ambas caras (CMYK / CMYK).
        //4+1 Impresos a todo color una cara y el reverso a blanco y negro(CMYK / K).
        //4+0 Impresos a todo color una cara y el reverso sin impresión(CMYK / – ).
        //1+1 Impresos a blanco y negro ambas caras(K / K)
        //1+0 Impreso blanco y negro una cara y el anverso sin impresión. (K / – )
        [BsonElement("colores_impresion")]
        public string colores_impresion { get; set; }
        [BsonElement("cantidad_ejemplares")]
        public Int32 cantidad_ejemplares { get; set; }
        // A1,2,3,4,5,Carta,Doble carta,Oficio,Folio,Tabloide,etc.
        [BsonElement("tamanio")]
        public string tamanio { get; set; }
        //couche, offset blanco, Cartulina Sulfatada, Bond, cartulina verjurada, opalina, bristol
        [BsonElement("tipo_hoja")]
        public string tipo_hoja { get; set; }
        [BsonElement("acabado_Hoja")]
        public string acabado_Hoja { get; set; }
        [BsonElement("orientacion")]
        public Boolean orientacion { get; set; }
        [BsonElement("archivos")]
        public List<string> archivos { get; set; }
    }
    public class beTalonario : beProducto_solicitud
    {
        public Boolean numerado { get; set; }
        public int copias { get; set; }
        public string encuadernado { get; set; }
    }
    public class beTarjetaPresentación : beProducto_solicitud
    {
        public Boolean plastificado { get; set; }
        public string acabado_plastificado { get; set; }
        public Boolean esquinas { get; set; }
    }
    public class beTriptico : beProducto_solicitud
    {
        public Boolean plegado { get; set; }
        public string tipo_plegado { get; set; }
    }
    public class beDiptico : beProducto_solicitud
    {
        public Boolean plegado { get; set; }
    }
}
