using MongoDB.Bson;
using MongoDB.Driver;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.MongoDbParams;
using SISGRAFH.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Infraestructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(doc => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(doc => doc.Id == id).SingleOrDefaultAsync();
        }

        public async Task<T> InsertOneAsync(T entity)
        {
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            var fechaActual = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, tst);

            entity.AudithObject = new Audith()
            {
                IdUsuarioCreacion = "-",
                UsuarioCreacion = "-",
                FechaCreacion = fechaActual,
            };
            await _collection.InsertOneAsync(entity);

            return entity;
        }

        public async Task<T> UpdateOneAsync(T entity)
        {
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            var fechaActual = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, tst);

            var newModification = new AudithModifications()
            {
                IdUsuario = "-",
                NombreUsuario = "-",
                FechaModificacion = fechaActual
            };
            entity.AudithObject.Modificaciones.Add(newModification);

            var filter = Builders<T>.Filter.Eq(doc => doc.Id, entity.Id);
            await _collection.FindOneAndReplaceAsync(filter, entity);
            return entity;
        }

        public async Task DeleteOneAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
            await _collection.FindOneAndDeleteAsync(filter);
        }
        public async Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression)
        {
            await _collection.DeleteManyAsync(filterExpression);
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }
    }
}
