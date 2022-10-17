using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.DTOs.Solicitud
{
    public class SolicitudDto
    {
        public string nombre_apellidos { get; set; }
        public string numero_celular { get; set; }
        public string correo { get; set; }
        public DateTime fecha_registro { get; set; } = DateTime.Now;
        public string codigo_cotizacion { get; set; }
        public string estado { get; set; }
        public List<Producto_solicitudDto> productos { get; set; }
    }
    public class Producto_solicitudDto
    {
        public string id_producto { get; set; }
        //4+4 Impresos a todo color ambas caras (CMYK / CMYK).
        //4+1 Impresos a todo color una cara y el reverso a blanco y negro(CMYK / K).
        //4+0 Impresos a todo color una cara y el reverso sin impresión(CMYK / – ).
        //1+1 Impresos a blanco y negro ambas caras(K / K)
        //1+0 Impreso blanco y negro una cara y el anverso sin impresión. (K / – )
        public string colores_impresion { get; set; }
        public Int32 cantidad_ejemplares { get; set; }
        // A1,2,3,4,5,Carta,Doble carta,Oficio,Folio,Tabloide,etc.
        public string tamanio { get; set; }
        //couche, offset blanco, Cartulina Sulfatada, Bond, cartulina verjurada, opalina, bristol
        public string tipo_hoja { get; set; }
        public string acabado_Hoja { get; set; }
        public List<string> archivos { get; set; }
    }
    public class TalonarioDto : Producto_solicitudDto
    {
        public Boolean numerado { get; set; }
        public int copias { get; set; }
        public string encuadernado { get; set; }
        public Boolean orientacion { get; set; }
    }
    public class TarjetaPresentaciónDto : Producto_solicitudDto
    {
        public Boolean plastificado { get; set; }
        public string acabado_plastificado { get; set; }
        public Boolean esquinas { get; set; }
    }
    public class TripticoDto : Producto_solicitudDto
    {
        public Boolean plegado { get; set; }
        public string tipo_plegado { get; set; }
        public Boolean orientacion { get; set; }
    }
    public class DipticoDto : Producto_solicitudDto
    {
        public Boolean plegado { get; set; }
        public Boolean orientacion { get; set; }
    }
}
