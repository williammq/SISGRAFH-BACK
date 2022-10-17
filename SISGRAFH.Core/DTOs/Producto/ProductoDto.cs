using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISGRAFH.Core.Entities;

namespace SISGRAFH.Core.DTOs.Producto
{
   
    public class ProductoDto
    {
        public string Id { get; set; }
        public string descripcion_producto{ get; set; }
        public string url_imagen{ get; set; }
    }


}