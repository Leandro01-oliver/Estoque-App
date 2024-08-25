using System.Linq.Expressions;

namespace Estoque_App.Data.Repositories.Interface
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, int pageNumber = 1,
    int pageSize = 10, params Expression<Func<TEntity, object>>[]? includes);
        Task<TEntity?> GetByIdAsync(Guid id);
        void Update(TEntity entity);
    }
}
