using SISGRAFH.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<beUsuario>> GetUsuarios();
        Task<beUsuario> PostUsuario(beUsuario usuario);
    }
}