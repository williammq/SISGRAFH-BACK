﻿using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IClienteRepository : IRepository<beCliente>
    {
        Task<IEnumerable<beCliente>> GetClienteByCorreo(string correo);

        Task<IEnumerable<beCliente>> GetClienteByNombreApellido(string nombre, string apellidopaterno, string apellidomaterno);
        
        Task <IEnumerable<beCliente>> GetClienteByNumeroDocumento (string numeroDocumento);

        Task<IEnumerable<beCliente>> GetClienteByRUC(string ruc);
        
        Task<beCliente> GetClienteByProperty(beCliente beCliente);
    }
}
    