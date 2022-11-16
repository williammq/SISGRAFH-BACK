using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.DTOs.Insumo
{
    public class InsumoDto
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string unidad { get; set; }
        public string unidad_insumo { get; set; }
        public double cantidad_insumo { get; set; }
        public string categoria { get; set; }
        public string marca { get; set; }
        public double costo_unitario { get; set; }
        public int stock_disponible { get; set; }
    }
    public class EspiralDto : InsumoDto
    {
        public double diametro { get; set; }
        public string material { get; set; }
        public double longitud { get; set; }
        public double grosor_union { get; set; }
        public int numero_agujeros { get; set; }
    }

    public class TintaDto : InsumoDto
    {
        public string color { get; set; }
        public int rendimiento { get; set; }
        public string tecnologia_impresion { get; set; }
        public List<string> compatibilidad { get; set; }
    }

    //public class modelo_serie_Dto
    //{
    //    public string modelo { get; set; }
    //    public List<string> serie { get; set; }
    //}

    public class PapelDto : InsumoDto
    {
        public double ancho { get; set; }
        public double largo { get; set; }
        public double gramaje { get; set; }
        public string color { get; set; }
        public string tipo { get; set; }
    }

    public class Pelicula_adhesivaDto : InsumoDto
    {
        public double ancho { get; set; }
        public double grosor { get; set; }
        public string capa_superficie { get; set; }
        public string capa_adhesivo { get; set; }
        public string acabado { get; set; }
    }

    public class PlacaOffsetDto : InsumoDto
    {
        public double largo { get; set; }
        public double ancho { get; set; }
        public double grosor { get; set; }
        public string material { get; set; }
        public string tipo { get; set; }
        public string luz_seguro { get; set; }
        public string sensibilidad_minima { get; set; }
        public string sensibilidad_maxima { get; set; }
        public double tiempo_desarrollo_minimo { get; set; }
        public double tiempo_desarrollo_maximo { get; set; }
    }
}
