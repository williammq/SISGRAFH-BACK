using MongoDB.Bson;
using MongoDB.Driver;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.MongoDbParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Infraestructure.Repositories
{
    public class Orden_TrabajoRepository : BaseRepository<beOrden_Trabajo>, IOrden_TrabajoRepository
    {
        private readonly IMongoCollection<beOrden_Trabajo> _orden;
        private readonly IMongoCollection<beCounter> _counter;

        public Orden_TrabajoRepository(IMongoDatabase database) : base(database)
        {
            _orden = database.GetCollection<beOrden_Trabajo>(MongoCollectionNames.Orden_Trabajo);
            _counter = database.GetCollection<beCounter>(MongoCollectionNames.Counter);
        }
        public async Task<IEnumerable<beOrden_Trabajo>> GetOrdenes()
        {
            var ordenes = await _orden.Find(o => true).ToListAsync();
            return ordenes;
        }

        public async Task<IEnumerable<beOrden_Trabajo>> GetOrdenesByIDSolicitud(string id_solicitud)
        {
            var ordenes = await _orden.Find(o => o.id_solicitud==id_solicitud).ToListAsync();
            return ordenes;
        }

        public async Task<beOrden_Trabajo> PostOrdenTrabjo(beOrden_Trabajo orden)
        {
            var rpCounter = await ObtainCounterAndName("", "orden-trabajo-id");
            orden.codigo = rpCounter.nameWithFormat;
            await _orden.InsertOneAsync(orden);
            return orden;
        }

        public async Task<beRpGetCounterName> ObtainCounterAndName(string documentName, string counterIdName)
        {
            try
            {
                var bodyCounter = await GetNextNumberCode(counterIdName);
                var name = ObtainCounterAndName2(documentName, bodyCounter);
                return name;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<beCounter> GetNextNumberCode(string id_coleccion)
        {

            try
            {
                var counterQuery = Builders<beCounter>.Filter.Eq("_id", id_coleccion);

                var counterUpdate = new BsonDocument("$inc", new BsonDocument { { "sequence_value", 1 } });

                var findAndModifyResult = await _counter.FindOneAndUpdateAsync(counterQuery, counterUpdate).ConfigureAwait(true);

                findAndModifyResult.sequence_value += 1;
                return findAndModifyResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public beRpGetCounterName ObtainCounterAndName2(string documentName, beCounter counter)
        {
            try
            {
                int numberCode = counter.sequence_value;
                string strCode = numberCode.ToString();

                if (counter.format_code)
                {
                    strCode = (numberCode > 0 && numberCode < 9) ? "00" + numberCode : (numberCode < 100) ? "0" + numberCode : numberCode.ToString();
                }

                if (counter.reduce_name)
                {
                    documentName = new string(documentName
                    .Split(new char[] { ' ', '_', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.First())
                    .ToArray()).ToUpper();
                }

                string nameWithFormat = "";
                if (counter.show_pref_code)
                {
                    nameWithFormat += counter.prefix_code;
                    nameWithFormat += counter.separator_left;

                }
                nameWithFormat += documentName;

                if (counter.show_seq_value)
                {
                    nameWithFormat += counter.separator_right;
                    nameWithFormat += strCode;
                }

                return new beRpGetCounterName()
                {
                    numberCode = numberCode,
                    nameWithFormat = nameWithFormat
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<beOrden_Trabajo>> GetOrdenesByMaquina(string id_maquina)
        {
            var ordenes = await _orden.Find(o => o.instrucciones.Any(i=>i.id_maquina==id_maquina)).ToListAsync();
            return ordenes;
        }

        public async Task<beOrden_Trabajo> GetOrdenesByCodigo(string codigo)
        {
            var orden = await _orden.Find(o => o.codigo==codigo).FirstOrDefaultAsync();
            return orden;
        }
    }
}
