using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.DTOs.Usuario
{
    public class RestablecerContraseniaDto
    {
        public string correo { get; set; }
        public string clave_nueva { get; set; }
    }
}
