using MongoDB.Driver;
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
    public class MaquinaRepository: BaseRepository<beMaquina>,IMaquinaRepository
    {
        private readonly IMongoCollection<beMaquina> _maquina;

        public MaquinaRepository(IMongoDatabase database) : base(database)
        {
            _maquina = database.GetCollection<beMaquina>(MongoCollectionNames.Maquinas);
        }

        public async Task<IEnumerable<beMaquina>> GetMaquinas()
        {
            var maquinas = await _maquina.Find(maquina => true).ToListAsync();
            return maquinas;
        }

        public async Task<beMaquina> PostMaquina(beMaquina maquina)
        {
            await _maquina.InsertOneAsync(maquina);
            return maquina;
        }
    }
}
