using Estoque_App.Data.Entities;
using Estoque_App.Data.Repositories.Interface;

namespace Estoque_App.Data.Repositories
{
    public class MidiaRepository : BaseRepository<Midia>, IMidiaRepository
    {
        public MidiaRepository(DataContext db) : base(db)
        {
        }
    }
}
