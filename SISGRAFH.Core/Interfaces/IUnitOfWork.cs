using SISGRAFH.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Infraestructure.Data.Interfaces
{
    public interface IUnitOfWork
    {
        public IUsuarioRepository Usuario { get; }
        public IMaquinaRepository Maquina { get; }
        public ICotizacionRepository Cotizacion { get; }
        public IInsumoRepository Insumo { get; }
        public IProductoRepository Producto { get; }
        public ISolicitudRepository Solicitud { get; }
        public IMovimientoRepository Movimiento { get; }
        public IClienteRepository Cliente { get; }
        public ICatalogoRepository Catalogo { get; }
        public ITrabajadorRepository Trabajador { get; }
        public IOrden_TrabajoRepository Orden_Trabajo { get; }
        public IPagoRepository Pago { get; }
        public IUbigeoRepository Ubigeo { get; }
        public IPedidoRepository Pedido { get; }
        public IReporteProduccionRepository ReporteProduccion { get; }
    }
}
