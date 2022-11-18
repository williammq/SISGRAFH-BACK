using SISGRAFH.Core.Entities;
using System;
using SISGRAFH.Core.DTOs.Cotizacion;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface ICotizacionRepository : IRepository<beCotizacion>
    {
        Task<IEnumerable<beCotizacion>> GetCotizaciones();
        Task<beCotizacion> PostCotizacion(beCotizacion cotizacion);
        Task<beCotizacion> GetCotizacionByCodigoCotizacion(string codigo, string estado);
        Task<IEnumerable<beCotizacion>> GetCotizacionesByCodigoCotizacion(string codigo);
    }
}
