using Estoque_App.Data.Entities;
using Estoque_App.Data.Enuns;
using Estoque_App.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Estoque_App.Data.Repositories
{
    public class MidiaRepository : BaseRepository<Midia>, IMidiaRepository
    {
        public MidiaRepository(DataContext db) : base(db)
        {
        }

        public async Task<Midia?> GetByNomeETipoImagemAsync(string nome, TipoMidia tipoImagem)
        {
            var query = _dbSet.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Nome.Equals(nome) && x.TipoMidia.Equals(tipoImagem));
        }
    }
}
