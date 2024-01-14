using CleanArchitecture.Application.Contracts.Infraesctructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Infraestructure.Persistence;
using CleanArchitecture.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.Infraestructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IProductRepository, ProductRepository>();


            return services;
        }
    }
}
