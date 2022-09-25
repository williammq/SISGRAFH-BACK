using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<beUsuario>> GetUsuarios();
        Task<beUsuario> PostUsuario(beUsuario usuario);
    }
}
