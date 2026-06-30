using System.Linq.Expressions;

namespace Telewise.Api.Infrastructure.Repositories;

public interface IRepository<T>
{
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

    Task<T?> FirstOrDefaultAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default);

    Task InsertAsync(
        T entity,
        CancellationToken cancellationToken = default);

    Task ReplaceAsync(
        string id,
        T entity,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        string id,
        CancellationToken cancellationToken = default);
}