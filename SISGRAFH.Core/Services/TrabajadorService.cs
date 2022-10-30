using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Services
{
    public class TrabajadorService : ITrabajadorService
    {
        private static IUnitOfWork _unitOfWork;

        public TrabajadorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<beTrabajador>> GetAllTrabajadores()
        {
            return await _unitOfWork.Trabajador.GetAllAsync();
        }

        public async Task<beTrabajador> InsertTrabajador(beTrabajador _beTrabajador)
        {
            return await _unitOfWork.Trabajador.InsertOneAsync(_beTrabajador);
        }

        public async Task<beTrabajador> UpdateTrabajador(beTrabajador _beTrabajador)
        {
            return await _unitOfWork.Trabajador.UpdateOneAsync(_beTrabajador);
        }
    }
}
