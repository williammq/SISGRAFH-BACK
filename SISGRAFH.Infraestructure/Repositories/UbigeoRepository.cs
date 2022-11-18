using System;
using MongoDB.Driver;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.MongoDbParams;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SISGRAFH.Infraestructure.Repositories
{
    public class UbigeoRepository : BaseRepository<beUbigeo>, IUbigeoRepository
    {
        private readonly IMongoCollection<beUbigeo> _ubigeo;
        public UbigeoRepository(IMongoDatabase database) : base(database)
        {
            _ubigeo = database.GetCollection<beUbigeo>(MongoCollectionNames.Ubigeo); 
        }
        public async Task<List<beUbigeo>> GetAllUbigeo()
        {
            var ubigeos = new List<beUbigeo>();
            ubigeos = await _ubigeo.Find(ubigeo => true).ToListAsync();
            return ubigeos;
        }
        public async Task<beUbigeo> GetByIdUbigeo(string id)
        {
            var ubigeo = await _ubigeo.Find(ubigeo => ubigeo.ubigeo == id).FirstOrDefaultAsync();
            return ubigeo;
        }
    }
}
