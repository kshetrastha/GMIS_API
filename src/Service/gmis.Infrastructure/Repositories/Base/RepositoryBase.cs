using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Domain.Entities;
using gmis.Infrastructure.Persistence;
using gmis.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace gmis.Infrastructure.Repositories.Base
{
    public class RepositoryBase<T> : DbConnector, IRepositoryBase<T> where T : EntityBase
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(IConfiguration configuration, RepositoryContext repositoryContext) : base(configuration, repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _dbSet = repositoryContext.Set<T>();
        }


        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity) => _dbSet.Remove(entity);
        //public T FindById(int id) => __dbSet.Where(x => x.Id == id).FirstOrDefault();
        public T FindById(Guid id) => _dbSet.FirstOrDefault();
        public IQueryable<T> FindAll(bool trackChanges)
          => !trackChanges ? _dbSet.AsNoTracking() : _dbSet;
        public IQueryable<T> FindByCondition(
           Expression<System.Func<T, bool>> expression, bool trackChanges) =>
           !trackChanges ?
           _dbSet.Where(expression).AsNoTracking()
           : _dbSet.Where(expression);

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeString = null, bool trackChanges = true)
        {
            IQueryable<T> query = _dbSet;
            if (trackChanges) query = _dbSet.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);
            if (expression != null) query = query.Where(expression);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _repositoryContext.Entry(entity).State = EntityState.Modified;
            await _repositoryContext.SaveChangesAsync();
        }

        public void Update(T entity) => _dbSet.Update(entity);

        public void Create(T entity) => _dbSet.Add(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);
        public void Delete(Expression<System.Func<T, bool>> expression)
        {
            var data = _dbSet.Where(expression).AsNoTracking();
            foreach (T entity in data)
            {
                Delete(entity);
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities) => await _dbSet.AddRangeAsync(entities);
        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _repositoryContext.Entry(entity).State = EntityState.Modified;
            }
        }
        public async Task AddOrUpdateRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                var existingEntity = entities.FirstOrDefault(e => e.Equals(entity));

                if (existingEntity != null)
                {
                    Update(entity);
                }
                else
                {
                    Create(entity);
                }
            }
        }
    }
}
