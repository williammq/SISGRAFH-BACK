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
    public class ReporteVentaService : IReporteVentaService
    {
        private static IUnitOfWork _unitOfWork;
        private static IFileStorage _fileStorage;

        public ReporteVentaService(IUnitOfWork unitOfWork, IFileStorage fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<IEnumerable<beReporteVenta>> consulventa()
        {
            return await _unitOfWork.Venta.GetAllAsync();
        }
    }
}
