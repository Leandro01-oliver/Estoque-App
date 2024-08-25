using Estoque_App.Data.Entities;
using Estoque_App.Data.Enuns;
using Estoque_App.Data.Models;

namespace Estoque_App.Service.Interface
{
    public interface IMidiaService
    {
        Task AddAsync(MidiaVm midia);
        void Update(MidiaVm midia);
        Task<MidiaVm?> GetByNomeETipoImagemAsync(string nome, TipoMidia tipoImagem);
    }
}
