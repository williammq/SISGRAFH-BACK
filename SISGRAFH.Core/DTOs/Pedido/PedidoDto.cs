using SISGRAFH.Core.DTOs.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.DTOs.Pedido
{
    public class PedidoDto
    {
        public string Id { get; set; }
        public string id_solicitud { get; set; }
        public string id_cliente { get; set; }
        public string estado { get; set; }
        public List<Producto_solicitudDto> productos { get; set; }
    }
}
