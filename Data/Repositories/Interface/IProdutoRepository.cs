using Estoque_App.Data.Entities;
using System.Linq.Expressions;

namespace Estoque_App.Data.Repositories.Interface
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
       Task<Produto?> GetByNomeAsync(string nome);
        Task<IEnumerable<Produto>> GetAllFullIncludeAsync(Expression<Func<Produto, bool>>? expression = null, int pageNumber = 1,
int pageSize = 10);
        Task<Produto?> GetByIdFullIncludeAsync(Guid produtoId);
    }
}
