using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface ICotizacionService
    {
        Task<IEnumerable<beCotizacion>> GetCotizaciones();
        Task<beCotizacion> PostCotizacion(beCotizacion cotizacion);
        Task<beCotizacion> UpdateCotizacion(beCotizacion cotizacion);
    }
}
