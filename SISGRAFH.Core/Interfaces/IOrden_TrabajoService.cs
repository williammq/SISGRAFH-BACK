using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SISGRAFH.Core.Interfaces
{
    interface IOrden_TrabajoService
    {
        Task<IEnumerable<beOrden_Trabajo>> GetOrdenes();
        Task<beOrden_Trabajo> PostOrden(beOrden_Trabajo ot);
    }
}
