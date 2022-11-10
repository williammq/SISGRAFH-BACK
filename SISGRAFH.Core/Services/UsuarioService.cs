using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private static IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<beUsuario>> GetUsuarios()
        {
            //return await _unitOfWork.Usuario.GetUsuarios();
            return await _unitOfWork.Usuario.GetAllAsync();
        }

        public async Task<beUsuario> PostUsuario(beUsuario usuario)
        {
            usuario.Id = null;
            return await _unitOfWork.Usuario.InsertOneAsync(usuario);
        }

        public async Task<beUsuario> UpdateUser(beUsuario usuarioRq)
        {
            var userDb = await _unitOfWork.Usuario.GetByIdAsync(usuarioRq.Id);
            if (userDb == null)
            {
                return await PostUsuario(usuarioRq);
            };
            userDb.NombreUsuario = usuarioRq.NombreUsuario;
            userDb.TipoUsuario = usuarioRq.TipoUsuario;
            userDb.Roles = usuarioRq.Roles;
            userDb.Clave = usuarioRq.Clave;
            userDb.Estado = usuarioRq.Estado;
            userDb.correo_usuario = usuarioRq.correo_usuario;

            return await _unitOfWork.Usuario.UpdateOneAsync(userDb);
        }
    }
}
