using Estoque_App.Data.Entities;
using Estoque_App.Data.Models;
using System.Linq.Expressions;

namespace Estoque_App.Service.Interface
{
    public interface IProdutoService
    {
        Task AddAsync(ProdutoVm produto);
        void Update(ProdutoVm produto);
        Task<ProdutoVm?> GetByNomeAsync(string nome);
        Task<IEnumerable<ProdutoVm>> GetAllFullIncludeAsync(Expression<Func<ProdutoVm, bool>>? expression = null, int pageNumber = 1, int pageSize = 10);
        Task<ProdutoVm?> GetByIdFullIncludeAsync(Guid produtoId);
    }
}
