using gmis.Domain.Entities;
using System.Linq.Expressions;

namespace gmis.Application.Contracts.Persistence.Base
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> expression = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool trackChanges = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> expression = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       List<Expression<Func<T, object>>> includes = null,
                                       bool trackChanges = true);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void Update(T entity);
        void Create(T entity);
        void Delete(T entity);
        void Delete(Expression<System.Func<T, bool>> expression);
        T FindById(Guid id);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task AddOrUpdateRangeAsync(IEnumerable<T> entities);
    }
}
