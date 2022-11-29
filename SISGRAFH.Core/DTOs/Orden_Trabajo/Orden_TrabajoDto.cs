using SISGRAFH.Core.DTOs.Cotizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.DTOs.Orden_Trabajo
{
    public class Orden_TrabajoDto
    {
        public string Id { get; set; }
        public string codigo { get; set; }
        public string id_producto { get; set; }
        public string codigo_producto { get; set; }
        public string id_solicitud { get; set; }
        public string estado { get; set; }
        public List<localizacionDto> instrucciones { get; set; }
    }
}
