using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.DTOs.Cotizacion
{
    public class cotizacionDto
    {
        public string Id { get; set; }
        public string id_solicitud { get; set; }
        public string codigo_cotizacion { get; set; }
        //Pendiente, En evaluación, Aceptado, Rechazado, Renegociar
        public string estado { get; set; }
        //public DateTime fecha_registro { get; set; } = DateTime.Now;
        //public DateTime fecha_modificacion { get; set; } = DateTime.Now;
        //Las maquinas por las que debera pasar antes de llegar a ser despachado
        public List<ProductoCotizadoDto> productos_cotizados { get; set; }
    }
    public class ProductoCotizadoDto
    {
        public string id_producto { get; set; }
        public List<localizacionDto> localizaciones { get; set; }
    }
    public class localizacionDto
    {
        public string id_maquina { get; set; }
        public int numero_orden { get; set; }
        public List<insumoCotizacionDto> insumos { get; set; }
    }
    public class insumoCotizacionDto
    {
        public string id_insumo { get; set; }
        public string cantidad_requerida { get; set; }
    }
}
