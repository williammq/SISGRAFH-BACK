using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IOrden_TrabajoRepository : IRepository<beOrden_Trabajo>
    {
        Task<IEnumerable<beOrden_Trabajo>> GetOrdenes();
        Task<IEnumerable<beOrden_Trabajo>> GetOrdenesByIDSolicitud(string id_solicitud);
        Task<IEnumerable<beOrden_Trabajo>> GetOrdenesByMaquina(string id_maquina);
        Task<beOrden_Trabajo> GetOrdenesByCodigo(string codigo);
        Task<beOrden_Trabajo> PostOrdenTrabjo(beOrden_Trabajo orden);
    }
}
