using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SISGRAFH.Core.Interfaces
{
    public interface IOrden_TrabajoService
    {
        Task<IEnumerable<beOrden_Trabajo>> GetOrdenes();
        Task<IEnumerable<beOrden_Trabajo>> GetOrdenesByCodigoCotizacion(string codigo);
        Task<IEnumerable<beOrden_Trabajo>> GetOrdenesByIdMaquina(string id_maquina);
        Task<beOrden_Trabajo> GetOrdenById(string id);
        Task<beOrden_Trabajo> PostOrden(beOrden_Trabajo ot);
        Task<beOrden_Trabajo> UpdateOrden(beOrden_Trabajo ot);
        Task<beOrden_Trabajo> GetOrdenesByCodigo(string codigo);
        Task<List<beOrden_Trabajo>> GenerarOrdenesByCotizacion(string codigo);
    }
}
