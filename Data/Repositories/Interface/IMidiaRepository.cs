using Estoque_App.Data.Entities;
using Estoque_App.Data.Enuns;

namespace Estoque_App.Data.Repositories.Interface
{
    public interface IMidiaRepository : IBaseRepository<Midia>
    {
        Task<Midia?> GetByNomeETipoImagemAsync(string nome, TipoMidia tipoImagem);
    }
}
