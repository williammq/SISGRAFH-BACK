using System;
using MongoDB.Driver;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.MongoDbParams;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SISGRAFH.Infraestructure.Repositories
{
    public class MovimientoRepository : BaseRepository<beMovimiento>, IMovimientoRepository
    {
        private readonly IMongoCollection<beMovimiento> _movimiento;
        private readonly IMongoCollection<beCounter> _counter;

        public MovimientoRepository(IMongoDatabase database) : base(database)
        {
            _movimiento = database.GetCollection<beMovimiento>(MongoCollectionNames.Movimientos);
            _counter = database.GetCollection<beCounter>(MongoCollectionNames.Counter);
        }

        public async Task<IEnumerable<beMovimiento>> GetAllMovimiento()
        {
            var movimientos = await _movimiento.Find(movimiento => true).ToListAsync();
            return movimientos;
        }

        public async Task<beMovimiento> GetByIdMovimiento(string id)
        {
            var movimiento = await _movimiento.Find(movimiento => movimiento.Id == id).FirstOrDefaultAsync();
            return movimiento;
        }

        public async Task<beMovimiento> PostMovimiento(beMovimiento movimiento)
        {
            var rpCounter = await ObtainCounterAndName("", "movimiento-id");
            movimiento.codigo = rpCounter.nameWithFormat;
            await _movimiento.InsertOneAsync(movimiento);
            return movimiento;
        }

        public async Task<beMovimiento> UpdateMovimiento(beMovimiento movimiento)
        {
            var filter = Builders<beMovimiento>.Filter.Eq(doc => doc.Id, movimiento.Id);
            await _movimiento.FindOneAndReplaceAsync(filter, movimiento);
            return movimiento;
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
    }
}
