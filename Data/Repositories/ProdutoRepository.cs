using Estoque_App.Data.Entities;
using Estoque_App.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Estoque_App.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Produto>> GetAllFullIncludeAsync(Expression<Func<Produto, bool>>? expression = null, int pageNumber = 1, int pageSize = 10)
        {
            var query = _dbSet.AsNoTracking().Include(x => x.Midia)
                          .Skip((pageNumber - 1) * pageSize)
                          .Take(pageSize);

            var result = expression == null
                ? await query.ToListAsync()
                : await query.Where(expression).ToListAsync();

            return result;
        }

        public Task<Produto?> GetByIdFullIncludeAsync(Guid produtoId)
        {
            return _dbSet.AsNoTracking().Include(x => x.Midia).FirstOrDefaultAsync(x => x.ProdutoId.Equals(produtoId));
        }

        public Task<Produto?> GetByNomeAsync(string nome)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Nome.Equals(nome));
        }
    }
}
