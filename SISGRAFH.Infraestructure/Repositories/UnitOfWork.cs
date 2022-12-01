using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Data.Interfaces;
using SISGRAFH.Infraestructure.Data.MongoDB;
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
        public IInsumoRepository Insumo => new InsumoRepository(_dbContext.Database);
        public IProductoRepository Producto => new ProductoRepository(_dbContext.Database);
        public ISolicitudRepository Solicitud => new SolicitudRepository(_dbContext.Database);

        public IMovimientoRepository Movimiento => throw new NotImplementedException();

        public IClienteRepository Cliente => new ClienteRepository(_dbContext.Database);

        public ICatalogoRepository Catalogo => new CatalogoRepository(_dbContext.Database);

        public ITrabajadorRepository Trabajador => new TrabajadorRepository(_dbContext.Database);
        public IOrden_TrabajoRepository Orden_Trabajo => new Orden_TrabajoRepository(_dbContext.Database);

        public IPagoRepository Pago =>  new PagoRepository(_dbContext.Database);
        public IUbigeoRepository Ubigeo => new UbigeoRepository(_dbContext.Database);

        public IPedidoRepository Pedido => new PedidoRepository(_dbContext.Database);

        public IReporteProduccionRepository ReporteProduccion => new ReporteProduccionReposistory(_dbContext.Database);

        public IReporteMermaRepository ReporteMerma => new ReporteMermaRepository(_dbContext.Database);
    }
}
