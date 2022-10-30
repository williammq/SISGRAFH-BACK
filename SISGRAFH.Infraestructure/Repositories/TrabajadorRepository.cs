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
    public class TrabajadorRepository : BaseRepository<beTrabajador>, ITrabajadorRepository
    {
        private readonly IMongoCollection<beTrabajador> _trabajador;
        public TrabajadorRepository(IMongoDatabase database) : base(database)
        {
            _trabajador = database.GetCollection<beTrabajador>(MongoCollectionNames.Trabajadores);
        }
    }
}
