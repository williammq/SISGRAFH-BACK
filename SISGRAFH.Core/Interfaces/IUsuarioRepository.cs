using SISGRAFH.Core.DTOs.Login;
using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IUsuarioRepository : IRepository<beUsuario>
    {
        Task<IEnumerable<beUsuario>> GetUsuarios();
        Task<beUsuario> PostUsuario(beUsuario usuario);
        Task<beUsuario> GetUserByCredentials(AuthUserInfo authInfo);
        Task<beUsuario> UsuariobyCorreo(string correodestino);
    }
    
}
