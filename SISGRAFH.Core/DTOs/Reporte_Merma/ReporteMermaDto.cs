using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISGRAFH.Core.Entities;

namespace SISGRAFH.Core.DTOs.Reporte_Merma
{
    public class ReporteMermaDto
    {
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public Objinsumo Insumo { get; set; }
        public Objtrabajador Trabajador { get; set; }
        public string IdReporte { get; set; }
    }

    public class ObjinsumoDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public double Cantidad { get; set; }
    }
    public class ObjtrabajadorDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
}
