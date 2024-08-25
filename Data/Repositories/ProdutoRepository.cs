using Estoque_App.Data.Entities;
using Estoque_App.Data.Repositories.Interface;

namespace Estoque_App.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext db) : base(db)
        {
        }
    }
}
