using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISGRAFH.Core.Entities;


namespace SISGRAFH.Core.DTOs.Pago
{
    public class PagoDto
    {
        public string Id { get; set; }
        public string id_cliente{ get; set; }
        public double monto_pagado { get; set; }
        public List <string> url_imagen{ get; set; }
        public string estado { get; set; }
        public string motivo_rechazo { get; set; }
        public string codigo_cotizacion { get; set; }
    }
}
