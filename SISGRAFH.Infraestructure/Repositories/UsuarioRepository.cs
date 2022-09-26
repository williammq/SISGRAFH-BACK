using MongoDB.Driver;
using SISGRAFH.Core.DTOs.Usuario;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.MongoDbParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Infraestructure.Repositories
{
    public class UsuarioRepository : BaseRepository<beUsuario>, IUsuarioRepository
    {
        private readonly IMongoCollection<beUsuario> _usuario;

        public UsuarioRepository(IMongoDatabase database) : base(database)
        {
            _usuario = database.GetCollection<beUsuario>(MongoCollectionNames.Usuarios);
        }
        public async Task<IEnumerable<beUsuario>> GetUsuarios()
        {
            var usuarios = await _usuario.Find(usuario => true).ToListAsync();
            return usuarios;
        }

        public async Task<beUsuario> PostUsuario(beUsuario usuario)
        {
            await _usuario.InsertOneAsync(usuario);
            return usuario;
        }
    }
}
