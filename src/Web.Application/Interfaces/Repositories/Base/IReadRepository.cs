using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Web.Application.Interfaces.Repositories.Base
{
    public interface IReadRepository<T, TId> where T : BaseEntity<TId>
    {
        IQueryable<T> GetAll(Expression<Func<T?, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes);
        T? GetFirst(Expression<Func<T?, bool>> predicate);
        Task<T?> GetFirstAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes);
        T? GetSingle(Expression<Func<T?, bool>> predicate);
        Task<T?> GetSingleAsync(Expression<Func<T?, bool>> predicate, params Expression<Func<T, object>>[]? includes);
    }
}
