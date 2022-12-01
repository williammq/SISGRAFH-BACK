using SISGRAFH.Core.DTOs.Cotizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.DTOs.Reporte_Producción
{
    public class ReporteProduccionDto
    {
        public string id { get; set; }
        public string id_orden_trabajo { get; set; }
        public string id_maquina { get; set; }
        public int numero_instruccion { get; set; }
        public string id_usuario { get; set; }
        public DateTime fecha_hora_inicio { get; set; }
        public DateTime fecha_hora_fin { get; set; }
        public string estado { get; set; }
        public componenteDto entrada { get; set; }
        public componenteDto salida { get; set; }
        public List<InsumoProduccionDto> insumos_entrada { get; set; }
        public List<InsumoProduccionDto> insumos_salida { get; set; }
    }
    public class InsumoProduccionDto
    {
        public string id_insumo { get; set; }
        public double cantidad { get; set; }
        public int stock_usado { get; set; }
    }
}
