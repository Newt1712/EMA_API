using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Web.Application.Interfaces.Repositories.Base
{
    public interface IWriteRepository<T, TId> where T : BaseEntity<TId>
    {
        void Add(T entity);
        ValueTask AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }
}
