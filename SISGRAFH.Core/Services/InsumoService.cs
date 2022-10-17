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

        public async Task<beInsumo> GetInsumoById(string id)
        {
            return await _unitOfWork.Insumo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<beInsumo>> GetInsumos()
        {
            return await _unitOfWork.Insumo.GetAllAsync();
        }

        public async Task<beInsumo> PostInsumo(beInsumo insumo)
        {
            return await _unitOfWork.Insumo.InsertOneAsync(insumo);
        }

        public async Task<beInsumo> UpdateInsumo(beInsumo insumo)
        {
            var insumoDb = await _unitOfWork.Insumo.GetByIdAsync(insumo.Id);
            if (insumoDb == null)
            {
                return await PostInsumo(insumo);
            };
            insumoDb.nombre = insumo.nombre;
            insumoDb.descripcion = insumo.descripcion;
            insumoDb.unidad = insumo.unidad;
            insumoDb.unidad_insumo = insumo.unidad_insumo;
            insumoDb.cantidad_insumo = insumo.cantidad_insumo;
            insumoDb.categoria = insumo.categoria;
            insumoDb.marca = insumo.marca;
            insumoDb.costo_unitario = insumo.costo_unitario;
            insumoDb.stock_disponible = insumo.stock_disponible;
            switch (insumoDb.GetType().Name)
            {
                case "beEspiral": 
                    var esp=(beEspiral)insumoDb;
                    var espiralPut=(beEspiral)insumo;
                    esp.diametro = espiralPut.diametro;
                    esp.longitud = espiralPut.longitud;
                    esp.grosor_union = espiralPut.grosor_union;
                    esp.numero_agujeros = espiralPut.numero_agujeros;
                    esp.material = espiralPut.material;
                    break;
                case "beTinta":
                    var tinta = (beTinta)insumoDb;
                    var tintaPut = (beTinta)insumo;
                    tinta.compatibilidad = tintaPut.compatibilidad;
                    tinta.color = tintaPut.color;
                    tinta.rendimiento = tintaPut.rendimiento;
                    tinta.tecnologia_impresion = tintaPut.tecnologia_impresion;
                    break;
                case "bePapel":
                    var papel = (bePapel)insumoDb;
                    var papelPut = (bePapel)insumo;
                    papel.ancho = papelPut.ancho;
                    papel.largo = papelPut.largo;
                    papel.gramaje = papelPut.gramaje;
                    papel.tipo = papelPut.tipo;
                    papel.color = papelPut.color;
                    break;
                case "bePelicula_adhesiva":
                    var pelicula = (bePelicula_adhesiva)insumoDb;
                    var peliculaPut = (bePelicula_adhesiva)insumo;
                    pelicula.ancho = peliculaPut.ancho;
                    pelicula.grosor = peliculaPut.grosor;
                    pelicula.capa_adhesivo = peliculaPut.capa_adhesivo;
                    pelicula.capa_superficie = peliculaPut.capa_superficie;
                    pelicula.acabado = peliculaPut.acabado;
                    break;
            }
            return await _unitOfWork.Insumo.UpdateOneAsync(insumoDb);
        }
    }
}
