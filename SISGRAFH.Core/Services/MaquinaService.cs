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
    public class MaquinaService : IMaquinaService
    {
        private static IUnitOfWork _unitOfWork;

        public MaquinaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<object>> GetMaquinas()
        {
            return await _unitOfWork.Maquina.GetAllAsync();
        }

        public async Task<beMaquina> PostMaquina(beMaquina maquina)
        {
            return await _unitOfWork.Maquina.InsertOneAsync(maquina);
        }

        public async Task<beMaquina> UpdateMaquina(beMaquina maquina)
        {
            var maquinaDb = await _unitOfWork.Maquina.GetByIdAsync(maquina.Id);
            if (maquinaDb == null)
            {
                return await PostMaquina(maquina);
            };
            maquinaDb.nombre = maquina.nombre;
            maquinaDb.descripcion = maquina.descripcion;
            maquinaDb.marca = maquina.marca;
            maquinaDb.url_imagen = maquina.url_imagen;
            maquinaDb.tipo_maquina = maquina.tipo_maquina;
            switch (maquinaDb.GetType().Name)
            {
                case "beGuillotina":
                    var gui = (beGuillotina)maquinaDb;
                    var guiPut = (beGuillotina)maquina;
                    gui.longitud_corte = guiPut.longitud_corte;
                    gui.altura_corte = guiPut.altura_corte;
                    break;
                case "beImpresoraDigital":
                    var imp = (beImpresoraDigital)maquinaDb;
                    var impPut = (beImpresoraDigital)maquina;
                    imp.area_maxima_hoja = impPut.area_maxima_hoja;
                    imp.area_minima_hoja = impPut.area_minima_hoja;
                    imp.modelo = impPut.modelo;
                    imp.serie = impPut.serie;
                    imp.tipo = impPut.tipo;
                    imp.velocidad_BN = impPut.velocidad_BN;
                    imp.velocidad_color = impPut.velocidad_color;
                    break;
                case "beLaminadora":
                    var lam = (beLaminadora)maquinaDb;
                    var lamPut = (beLaminadora)maquina;
                    lam.ancho_maximo_laminacion = lamPut.ancho_maximo_laminacion;
                    lam.grosor_laminacion_maximo = lamPut.grosor_laminacion_maximo;
                    lam.velocidad = lamPut.velocidad;
                    break;
                case "beTroqueladora":
                    var troq = (beTroqueladora)maquinaDb;
                    var troqPut = (beTroqueladora)maquina;
                    troq.capacidad = troqPut.capacidad;
                    troq.cuchilla = troqPut.cuchilla;
                    break;
                case "beHendidora":
                    var hen = (beHendidora)maquinaDb;
                    var henPut = (beHendidora)maquina;
                    hen.ancho_maximo_plegado = henPut.ancho_maximo_plegado;
                    hen.profundidad_plegado = henPut.profundidad_plegado;
                    break;
            }
            return await _unitOfWork.Maquina.UpdateOneAsync(maquinaDb);
        }
    }
}
