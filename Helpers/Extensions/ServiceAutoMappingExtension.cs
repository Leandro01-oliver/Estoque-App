using AutoMapper;
using Estoque_App.Data.Configs;

namespace API.Helpers.Extensions
{
    public static class ServiceAutoMappingExtension
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(item =>
            {
                item.AddProfile(new ConfigurationMapping());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
