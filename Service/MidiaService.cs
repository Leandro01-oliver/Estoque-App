using AutoMapper;
using Estoque_App.Data.Entities;
using Estoque_App.Data.Enuns;
using Estoque_App.Data.Models;
using Estoque_App.Data.Repositories.Interface;
using Estoque_App.Service.Interface;

namespace Estoque_App.Service
{
    public class MidiaService : IMidiaService
    {
        private readonly IMidiaRepository _midiaRepository;
        private readonly IMapper _mapper;
        public MidiaService(IMidiaRepository midiaRepository, IMapper mapper)
        {
            _midiaRepository = midiaRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(MidiaVm midia)
        {
            await _midiaRepository.AddAsync(_mapper.Map<Midia>(midia));
        }

        public async Task<MidiaVm?> GetByNomeETipoImagemAsync(string nome, TipoMidia tipoImagem)
        {
            return _mapper.Map<MidiaVm>(await _midiaRepository.GetByNomeETipoImagemAsync(nome, tipoImagem));
        }

        public void Update(MidiaVm midia)
        {
            _midiaRepository.Update(_mapper.Map<Midia>(midia));
        }
    }
}
