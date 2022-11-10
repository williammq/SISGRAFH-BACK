using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.DTOs.Login;

namespace SISGRAFH.Core.Interfaces
{
    public interface IPagoRepository : IRepository<bePago>
    {
        Task<bePago> PostPago(bePago pago);
        Task<bePago> GetPagoByIdCliente(string idcliente);

    }
}
