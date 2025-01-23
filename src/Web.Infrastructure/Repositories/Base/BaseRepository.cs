using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Interfaces.Repositories.Base;
using Web.Domain.Entities;
using Web.Infrastructure.DBContext;

namespace Web.Infrastructure.Repositories.Base
{
    public class BaseRepository<T, TId> : IBaseRepository<T, TId> where T : BaseEntity<TId>
    {
        private readonly DbSet<T> _entities;
        private readonly ApplicationDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            Guard.Against.Null(entity, nameof(entity));
            _entities.Add(entity);
        }

        public async ValueTask AddAsync(T entity)
        {
            Guard.Against.Null(entity, nameof(entity));
            await _entities.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T?> entities)
        {
            _entities.AddRange(entities);
        }

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            Guard.Against.Null(entity, nameof(entity));
            _entities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            Guard.Against.Null(entities, nameof(entities));
            _entities.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Guard.Against.Null(entity, nameof(entity));
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Guard.Against.Null(entities, nameof(entities));
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public T? GetFirst(Expression<Func<T?, bool>> predicate)
        {
            return GetEntities(false).FirstOrDefault(predicate);
        }

        public async Task<T?> GetFirstAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = GetEntities(false);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return predicate != null ? await query.FirstOrDefaultAsync(predicate) : await query.FirstOrDefaultAsync();
        }

        public T? GetSingle(Expression<Func<T?, bool>> predicate)
        {
            return GetEntities(false).SingleOrDefault(predicate);
        }
        public async Task<T?> GetSingleAsync(Expression<Func<T?, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = GetEntities(false);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return predicate != null ? await query.SingleOrDefaultAsync(predicate) : await query.SingleOrDefaultAsync();
        }
        public IQueryable<T> GetAll(Expression<Func<T?, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = GetEntities(false);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(predicate);
        }

        private IQueryable<T> GetEntities(bool asNoTracking = true)
        {
            if (asNoTracking)
                return _entities.AsNoTracking();
            return _entities;
        }

        public Task SaveChangesAsync(CancellationToken token = default)
        {
            return _context.SaveChangesAsync(token);
        }


    }
}
