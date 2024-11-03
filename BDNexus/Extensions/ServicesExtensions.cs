using _Nexus.DataBase;
using _Nexus.Models;
using _Nexus.Repository;
using BDNexus.Configuration;
using BDNexus.UseCase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace BDNexus.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, APIConfiguration appConfiguration)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = appConfiguration.Swagger.Title,
                    Version = "v1",
                    Description = appConfiguration.Swagger.Description,
                    Contact = new OpenApiContact() { Email = appConfiguration.Swagger.Email, Name = appConfiguration.Swagger.Name }
                });
            });

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<UsuarioUseCase>();
            services.AddScoped<PedidosUseCase>();
            services.AddScoped<ProdutoUseCase>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<PedidosModel>, Repository<PedidosModel>>();
            services.AddScoped<IRepository<UsuarioModel>, Repository<UsuarioModel>>();
            services.AddScoped<IRepository<ProdutosModel>, Repository<ProdutosModel>>();
            return services;
        }

        public static IServiceCollection AddMongoDbContext(this IServiceCollection services, APIConfiguration appConfiguration)
        {
            services.AddDbContext<Context>(options =>
            {
                options.UseMongoDB(appConfiguration.MongoDbConnectionString, appConfiguration.MongoDbDatabase);
            });
            return services;
        }
    }
}