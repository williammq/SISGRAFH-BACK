using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISGRAFH.Core.Entities;

namespace SISGRAFH.Core.DTOs.Producto
{
    //DTO para Insert/Update
    public class ProductoDto
    {
        public string Id { get; set; }
        public string descripcion_producto{ get; set; }
        public double Largo { get; set; }
        public double Ancho { get; set; }
    }


}