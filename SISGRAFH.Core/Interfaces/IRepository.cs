using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> InsertOneAsync(T entity);
        Task<T> UpdateOneAsync(T entity);
        Task DeleteOneAsync(string id);
        Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression);

    }
}
