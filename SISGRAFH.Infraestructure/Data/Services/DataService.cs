using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Data.Interfaces;
using SISGRAFH.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Infraestructure.Data.Services
{
    public class DataService : IDataService
    {
        private readonly MongoContext _dbContext;

        public DataService(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUsuarioRepository Usuario => new UsuarioRepository(_dbContext.Database);
    }
}
