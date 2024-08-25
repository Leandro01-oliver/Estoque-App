
using AutoMapper;
using Estoque_App.Data.Entities;
using Estoque_App.Data.Models;

namespace Estoque_App.Data.Configs
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Produto, ProdutoVm>().ForMember(dest => dest.MidiaVm, opt => opt.MapFrom(src => src.Midia)).ReverseMap().PreserveReferences();
            CreateMap<Midia, MidiaVm>().ReverseMap().PreserveReferences();
        }
    }
}
