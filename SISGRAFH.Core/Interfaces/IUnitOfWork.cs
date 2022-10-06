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
    }
}
