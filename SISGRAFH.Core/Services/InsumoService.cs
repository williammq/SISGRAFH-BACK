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
    public class InsumoService : IInsumoService
    {
        private static IUnitOfWork _unitOfWork;

        public InsumoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<object> GetInsumoById(string id)
        {
            return await _unitOfWork.Insumo.GetInsumoById(id);
        }

        public async Task<IEnumerable<object>> GetInsumos()
        {
            return await _unitOfWork.Insumo.GetAllAsync();
        }

        public async Task<beInsumo> PostInsumo(beInsumo insumo)
        {
            return await _unitOfWork.Insumo.InsertOneAsync(insumo);
        }


        //public async Task<beInsumo> UpdateInsumo(beInsumo insumo)
        //{

        //    var userDb = await _unitOfWork.Insumo.GetByIdAsync(insumo.Id);
        //    if(userDb == null)
        //    {
        //        return await PostInsumo(insumo);
        //    }

        //    userDb.nombre = insumo.nombre;
        //    userDb.descripcion = insumo.descripcion;
        //    userDb.unidad = insumo.unidad;
        //    userDb.unidad_insumo = insumo.unidad_insumo;
        //    userDb.cantidad_insumo = insumo.cantidad_insumo;
        //    userDb.categoria = insumo.categoria;
        //    userDb.marca = insumo.marca;
        //    userDb.costo_unitario = insumo.costo_unitario;
        //    userDb.stock_disponible = insumo.stock_disponible;

        //    switch (userDb.categoria)
        //    {
        //        case "Espiral": userDb.
        //        case "Tinta":
        //        case "Soporte de Impresión":
        //        case "Pelicula": 
        //    }

        //    return await _unitOfWork.Insumo.UpdateOneAsync(userDb);
        //}
    }
}
