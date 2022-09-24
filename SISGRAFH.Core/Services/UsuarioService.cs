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
        //private static IUsuarioRepository _usuarioRepository;
        private static IUsuarioRepository _usuarioRepository;
        private static IDataService _dataService;

        public UsuarioService(IDataService dataService)
        {
            _usuarioRepository = dataService.Usuario;
            _dataService = dataService;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _usuarioRepository.GetUsuarios();
        }

    }
}
