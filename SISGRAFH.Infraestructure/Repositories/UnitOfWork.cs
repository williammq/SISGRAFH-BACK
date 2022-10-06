using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Data;
using SISGRAFH.Infraestructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MongoContext _dbContext;

        public UnitOfWork(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUsuarioRepository Usuario => new UsuarioRepository(_dbContext.Database);
        public IMaquinaRepository Maquina => new MaquinaRepository(_dbContext.Database);
        public ICotizacionRepository Cotizacion => new CotizacionRepository(_dbContext.Database);
    }
}
