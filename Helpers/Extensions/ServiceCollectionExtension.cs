using Estoque_App.Data;
using Estoque_App.Data.Repositories;
using Estoque_App.Data.Repositories.Interface;
using Estoque_App.Service;
using Estoque_App.Service.Interface;
using Firebase.Auth;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddScopeds(this IServiceCollection services)
        {



            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IMidiaService, MidiaService>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IMidiaRepository, MidiaRepository>();

            // Serviço do firebase para o storage
            services.AddScoped<IFirebaseService, FirebaseService>();
            services.AddScoped<IFirebaseRepository, FirebaseRepository>();

            return services;
        }
        public static IServiceCollection AddDbContext(this IServiceCollection services, string defaultConnection)
        {
            return services.AddDbContext<DataContext>(options => options.UseSqlServer(defaultConnection));
        }
    }
}
