using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISGRAFH.Core.Entities;

namespace SISGRAFH.Core.DTOs.Catalogo
{
    
    public class CatalogoDto
    {
       public string Id { get; set; }
       public List<beTamanioHoja> tamanios { get; set; }
       public List<string> tipos_hoja { get; set; }
       public boolean estadoProducto { get; set; }
       
    }

    public class beTamanioHojaDto{
         
        public double largo{ get; set; }
         
        public double ancho{ get; set; }
        
        public double nombreTamanio{ get; set; }



    }
}