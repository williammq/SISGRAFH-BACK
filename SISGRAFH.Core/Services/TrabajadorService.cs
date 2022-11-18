using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.BlobStorage;
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
        private static IFileStorage _fileStorage;

        public TrabajadorService(IUnitOfWork unitOfWork, IFileStorage fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage= fileStorage;
        }

        public async Task<IEnumerable<beTrabajador>> GetAllTrabajadores()
        {
            return await _unitOfWork.Trabajador.GetAllAsync();
        }

        public async Task<beTrabajador> GetTrabajadorById(string id)
        {
            return await _unitOfWork.Trabajador.GetByIdAsync(id);
        }

        public async Task<beTrabajador> InsertTrabajador(beTrabajador _beTrabajador)
        {
            string base64String = _beTrabajador.Foto.Split(",")[1];
            _beTrabajador.Foto = await _fileStorage.SaveFile(Convert.FromBase64String(base64String), "jpg", "sisgraphfiles");

            return await _unitOfWork.Trabajador.InsertOneAsync(_beTrabajador);
        }

        public async Task<beTrabajador> UpdateTrabajador(beTrabajador _beTrabajador)
        {
            return await _unitOfWork.Trabajador.UpdateOneAsync(_beTrabajador);
        }
    }
}
