using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.DTOs.Movimiento
{
    public class MovimientoDto
    {
        public string Id { get; set; }
        public int cantidad { get; set; }
        public string codigo { get; set; }
        public string tipo { get; set; }
        public OrigenDto origen { get; set; }
        public DestinoDto destino { get; set; }
        public List<MovimientoInsumoDto> insumo { get; set; }
        public TransporteDto transporte { get; set; }
        public string estado { get; set; }
        public DateTime fecha_movimiento { get; set; } = DateTime.Now;
    }

    public class OrigenDestinoDto
    {
        public string ubigeo { get; set; }
        public string direccion { get; set; }
        public string local { get; set; }
    }
    public class OrigenDto : OrigenDestinoDto
    {
        public string emisor { get; set; }
    }
    public class DestinoDto : OrigenDestinoDto
    {
        public string receptor { get; set; }
    }
    public class TransporteDto
    {
        public string transportista { get; set; }
        public string marca_vehiculo { get; set; }
        public string placa_vehiculo { get; set; }
    }
    public class MovimientoInsumoDto
    {
        public string codigo_insumo { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
    }
}
