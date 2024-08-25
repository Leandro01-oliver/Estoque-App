using AutoMapper;
using Estoque_App.Data.Entities;
using Estoque_App.Data.Models;
using Estoque_App.Data.Repositories.Interface;
using Estoque_App.Service.Interface;
using System.Linq.Expressions;

namespace Estoque_App.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProdutoVm produto)
        {
           await _produtoRepository.AddAsync(_mapper.Map<Produto>(produto));
        }

        public async Task<IEnumerable<ProdutoVm>> GetAllFullIncludeAsync(Expression<Func<ProdutoVm, bool>>? expression = null, int pageNumber = 1, int pageSize = 10)
        {
            var expressionMapping = _mapper.Map<Expression<Func<Produto, bool>>?>(expression);
            IEnumerable<Produto> a = await _produtoRepository.GetAllFullIncludeAsync(expressionMapping, pageNumber, pageSize);
            IEnumerable<ProdutoVm> b = _mapper.Map<IEnumerable<ProdutoVm>>(await _produtoRepository.GetAllFullIncludeAsync(expressionMapping, pageNumber, pageSize));
           return b;
        }

        public async Task<ProdutoVm?> GetByIdFullIncludeAsync(Guid produtoId)
        {
            return _mapper.Map<ProdutoVm>(await _produtoRepository.GetByIdFullIncludeAsync(produtoId));
        }

        public async Task<ProdutoVm?> GetByNomeAsync(string nome)
        {
            return _mapper.Map<ProdutoVm>(await _produtoRepository.GetByNomeAsync(nome));
        }

        public void Update(ProdutoVm produto)
        {
            _produtoRepository.Update(_mapper.Map<Produto>(produto));
        }
    }
}
