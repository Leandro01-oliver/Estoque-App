
using AutoMapper;
using Estoque_App.Data.Entities;
using Estoque_App.Data.Models;

namespace Estoque_App.Data.Configs
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Produto, ProdutoVm>().ReverseMap().PreserveReferences();
            CreateMap<Midia, MidiaVm>().ReverseMap().PreserveReferences();
        }
    }
}
