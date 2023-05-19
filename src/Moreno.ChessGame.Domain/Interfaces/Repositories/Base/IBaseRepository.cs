using System.Linq.Expressions;

namespace Moreno.ChessGame.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository<T> where T : Entity
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> UpdateAsync(T updated, int key);
    Task DeleteAsync(Guid id);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(Expression<Func<T, bool>>? filter = null);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(object id);
    Task<(IEnumerable<T> items, int qtd)> GetAsync(Expression<Func<T, bool>>? filter = null,
        params Expression<Func<T, object>>[] includes);

    Task<T> GetUniqueAsync(Expression<Func<T, bool>> expression);

    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);

    Task<IEnumerable<T>> GetToWriteAsync(Expression<Func<T, bool>> predicate);

    Task<int> CommitAsync();
}