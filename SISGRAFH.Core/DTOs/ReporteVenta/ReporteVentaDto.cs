using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISGRAFH.Core.DTOs.Pago;
using SISGRAFH.Core.Entities;

namespace SISGRAFH.Core.DTOs.ReporteVenta
{
   public class ReporteVentaDto
    {
        public string id { get; set; }
        public string id_cliente { get; set; }      
        public string estado { get; set; }
        public DateTime fecha_de_registro { get; set; }
        public string reporte { get; set; }
        public List<PagoDto> pagos { get; set; }
    }
}
